using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D = null;         // 剛体
    public float jumpForce = 5000000000.0f;    // ジャンプ力
    bool isJumping = false;             // ジャンプ中か否か
    public float walkSpeed = 5000.0f;   // 歩く速度

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ジャンプ処理
        JumpUpdate();

        // 移動処理
        MoveUpdate();

        // ブロックの破壊処理
        //BreakBlock();
    }

    // 移動処理
    void MoveUpdate()
	{
        float h = Input.GetAxisRaw("Horizontal");           // 横の入力情報
        float velocityY = this.rigid2D.velocity.y;          // 縦の移動量
        Vector2 velocity = new Vector2(0.0f, velocityY);    // 移動量

        // 横移動
        if (Mathf.Abs(h) > 0.0f)
        {
            velocity = new Vector2(h * walkSpeed, velocityY);
        }

        // 動く方向に応じて反転
        if (h != 0)
        {
            Vector3 localScale = transform.localScale;
            float absLocalScaleX = Mathf.Abs(localScale.x);
            localScale.x = h > 0.0f ? absLocalScaleX : absLocalScaleX * -1.0f;
            transform.localScale = localScale;
        }

        // 移動量の設定
        this.rigid2D.velocity = velocity;
    }

    // ジャンプする関数
    void JumpUpdate()
    {
        if(isJumping)
		{ // 着地していない
            return;
		}

        if (Input.GetKeyDown(KeyCode.W) || 
            Input.GetKeyDown(KeyCode.UpArrow))
		{ // W キー，もしくは上矢印キーを押した
            isJumping = true;  // ジャンプしている状態にする
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
    }

    // 衝突検出処理
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("test");

        if (other.gameObject.tag == "ou")
        {
            Debug.Log("凹");
        }
        else if (other.gameObject.tag == "totu")
        {
            Debug.Log("凸");
        }
    }

    // 2D オブジェクトとの当たり判定の検出
    void OnCollisionEnter2D(Collision2D other)
    {
        float minDistance = 100000000.0f;   // 最短距離
        ContactPoint2D contact2d;           // 接触しているオブジェクト

        foreach (var contact in other.contacts)
        {
            Vector2 dir = contact.point - (Vector2)transform.position;
            float distance = dir.sqrMagnitude;
            if(distance < minDistance)
			{ // こっちのオブジェクトの方が近かった
                distance = minDistance;
                contact2d = contact;
            }

            float nor = -contact.normal.sqrMagnitude;
            if (nor < 0.7f)
			{
                isJumping = false;
            }
        }

        // 衝突したオブジェクトのタグを取得
        if (other.gameObject.tag == "ou")
        {
            Debug.Log("凹");
        }
        else if (other.gameObject.tag == "totu")
        {
            Debug.Log("凸");
        }
    }

#if false
    // ブロックの破壊
    void BreakBlock()
	{
        if ()
		{

		}
	}
#endif
}
