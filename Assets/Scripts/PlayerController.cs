using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D = null; // 剛体
    public float jumpForce = 70000.0f; // ジャンプ力
    public float walkSpeed = 500.0f; // 歩く速度
    bool isJumping = false; // ジャンプ中か否か
    string prevDugTag = "none"; // 前回堀ったブロックのタグ
    int hp = 100; // スタミナ
    bool isDig = false; // 掘るか否か
    bool isDigLeft = false; // 左を掘る
    bool isDigRight = false; // 右を掘る
    bool isDigUnder = false; // 下を掘る
    Animator animator; // アニメーター

    void Awake()
    {
        GameManager.PlayerObject = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ジャンプ処理
        JumpUpdate();

        // 移動処理
        MoveUpdate();

        // 入力処理
        InputUpdate();

        // ゲームオーバー
        if(hp <= 0)
		{
            hp = 0;
            GameOver();
		}

        if(transform.position.y <= -3500.0f)
		{
            GameOver();
		}
    }

    // 入力処理
    void InputUpdate()
    {
        isDig = Input.GetKeyDown(KeyCode.Space); // 掘るか否か
        isDigLeft = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftArrow); // 左を掘る
        isDigRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow); // 右を掘る
        isDigUnder = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow); // 下を掘る

#if UNITY_EDITOR // デバッグ
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameManager.HealthBar.DecHP(10);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameManager.HealthBar.RecoveryHP(10);
        }
#endif
    }

    // 移動処理
    void MoveUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // 横の入力情報
        float velocityY = this.rigid2D.velocity.y; // 縦の移動量
        Vector2 velocity = new Vector2(0.0f, velocityY); // 移動量
        this.animator.SetBool("walk", false);

        // 横移動
        if (Mathf.Abs(h) > 0.0f)
        {
            this.animator.SetBool("walk", true);
            velocity = new Vector2(h * walkSpeed, velocityY);
        }

        // 動く方向に応じて反転
        if (h != 0)
        {
            Vector3 localScale = transform.localScale;
            float absLocalScaleX = Mathf.Abs(localScale.x);
            localScale.x = (h > 0.0f) ? absLocalScaleX : (absLocalScaleX * -1.0f);
            transform.localScale = localScale;
        }

        // 移動量の設定
        this.rigid2D.velocity = velocity;
    }

    // ジャンプする関数
    void JumpUpdate()
    {
        if (isJumping)
        { // 着地していない
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            sound snd = FindObjectOfType<sound>();
            if (snd)
            {
                snd.jamp1();
            }
            // W キー，もしくは上矢印キーを押した
            isJumping = true; // ジャンプしている状態にする
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            this.animator.SetTrigger("JumpTrigger");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "drop")
        {
            dropitem it = other.gameObject.GetComponent<dropitem>();
            if (it)
            {
                if (it.Type == dropitem.ItemType.STAMINA_RESTORE)
                {
                    GameManager.HealthBar.RecoveryHP(10);
                    Destroy(other.gameObject);
                } 
                else if (it.Type == dropitem.ItemType.SCORE_TREASURE)
                {
                    GameManager.TreasureCount++;
                    Destroy(other.gameObject);
                } 
                else if (it.Type == dropitem.ItemType.SCORE_JEWEL)
                {
                    GameManager.JewelCount++;
                    Destroy(other.gameObject);
                }
            }
        }
    }

    // 2D オブジェクトとの当たり判定の検出
    void OnCollisionStay2D(Collision2D other)
    {
        GameObject closestObject = null; // 一番近いオブジェクト
        float closestDistance = float.MaxValue; // 最短距離
        string dirType = "none"; // 向き

        foreach (ContactPoint2D contact in other.contacts)
        {
            GameObject otherObject = contact.collider.gameObject; // 衝突しているオブジェクト
            Vector2 playerPos = transform.position; // プレイヤーの位置
            Vector2 objectPos = otherObject.transform.position; // 衝突しているオブジェクトの位置
            Vector2 dir = objectPos - playerPos; // 向き

            // 方向の取得
            if (dir.x != 0.0f || dir.y != 0.0f)
            {
                if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
                { // 横の方向の取得
                    dirType = dir.x > 0 ? "right" : "left";
                }
                else
                { // 縦の方向の取得
                    if (dir.y <= 0)
                    {
                        isJumping = false; // ジャンプしていない状態にする
                        dirType = "under";
                    }
                }
            }

            // 一番近いオブジェクトの更新
            float distance = Vector2.Distance(transform.position, otherObject.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = otherObject;
            }
        }

        // 掘る
        if (closestObject != null &&
            isDig)
        { // オブジェクトが空じゃない，かつ掘るフラグが真

            // 掘れるかどうかの判定
            bool canDig = false;
            string currDigTag = closestObject.tag;
            if (prevDugTag == "none")
            { // 始めて掘る
                canDig = true;
            }
            else
            { // 掘るのが始めてじゃない
                if (prevDugTag == "ou" && currDigTag == "totu")
                { // 前回 "凹", かつ今回 "凸"
                    canDig = true;
                }
                else if (prevDugTag == "totu" && currDigTag == "ou")
                { // 前回 "凸", かつ今回 "凹"
                    canDig = true;
                }

                if(other.gameObject.name.Contains("treasure"))
				{
                    GameClear();
                    Debug.Log("clear");
                }
            }

            if (canDig)
            { // 掘ることができる
                if((dirType == "left" && isDigLeft) ||
                    (dirType == "right" && isDigRight) ||
                    (dirType == "under" && isDigUnder))
				{
                    Dig(closestObject, dirType);
                }
            }
        }
    }

    // 掘る
    void Dig(GameObject dugObject, string dirType)
    {
        // 破棄
        block bl = dugObject.GetComponent<block>();
        if (bl)
        {
            bl.Deinit(); 
        }
        Destroy(dugObject);
        Debug.Log("堀ったオブジェクト: " + dugObject.name);
        Debug.Log(dirType);

        // 堀ったタグの更新
        prevDugTag = dugObject.tag;

        int damage = 2;
        if(dugObject.name.Contains("ganseki"))
		{
            damage = 4;
        }

        // スタミナバーを減らす
        GameManager.HealthBar.DecHP(damage);

        // スタミナを減らす
        hp -= damage;
    }

    // ゲームクリア
    public void GameClear()
    {
        // リザルトへ
        EndScreen.IsWin = true;
        SceneManager.LoadScene("End");
    }

    public void GameOver()
	{
        // リザルトへ？
        EndScreen.IsWin = false;
		SceneManager.LoadScene("End");
	}
}
