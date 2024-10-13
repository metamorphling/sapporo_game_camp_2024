using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D = null; // ����
    public float jumpForce = 70000.0f; // �W�����v��
    public float walkSpeed = 500.0f; // �������x
    bool isJumping = false; // �W�����v�����ۂ�
    string prevDugTag = "none"; // �O��x�����u���b�N�̃^�O
    int hp = 100; // �X�^�~�i
    bool isDig = false; // �@�邩�ۂ�
    bool isDigLeft = false; // �����@��
    bool isDigRight = false; // �E���@��
    bool isDigUnder = false; // �����@��

    public int m_index = 0;
    public int numImages;

    const string DIR_IMAGES = "Textures";
    SpriteRenderer m_SpriteRenderer;
    public Sprite m_Sprite;
    public Sprite[] m_Sprites;

    void Awake()
    {
        GameManager.PlayerObject = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // �W�����v����
        JumpUpdate();

        // �ړ�����
        MoveUpdate();

        // ���͏���
        InputUpdate();
    }

    // ���͏���
    void InputUpdate()
    {
        isDig = Input.GetKeyDown(KeyCode.Space); // �@�邩�ۂ�
        isDigLeft = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftArrow); // �����@��
        isDigRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow); // �E���@��
        isDigUnder = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow); // �����@��

#if UNITY_EDITOR // �f�o�b�O
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

    // �ړ�����
    void MoveUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // ���̓��͏��
        float velocityY = this.rigid2D.velocity.y; // �c�̈ړ���
        Vector2 velocity = new Vector2(0.0f, velocityY); // �ړ���

        // ���ړ�
        if (Mathf.Abs(h) > 0.0f)
        {
            velocity = new Vector2(h * walkSpeed, velocityY);
        }

        // ���������ɉ����Ĕ��]
        if (h != 0)
        {
            Vector3 localScale = transform.localScale;
            float absLocalScaleX = Mathf.Abs(localScale.x);
            localScale.x = (h > 0.0f) ? absLocalScaleX : (absLocalScaleX * -1.0f);
            transform.localScale = localScale;
        }

        // �ړ��ʂ̐ݒ�
        this.rigid2D.velocity = velocity;
    }

    // �W�����v����֐�
    void JumpUpdate()
    {
        if (isJumping)
        { // ���n���Ă��Ȃ�
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        { // W �L�[�C�������͏���L�[��������
            isJumping = true; // �W�����v���Ă����Ԃɂ���
            this.rigid2D.AddForce(transform.up * this.jumpForce);
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

    // 2D �I�u�W�F�N�g�Ƃ̓����蔻��̌��o
    void OnCollisionStay2D(Collision2D other)
    {
        GameObject closestObject = null; // ��ԋ߂��I�u�W�F�N�g
        float closestDistance = float.MaxValue; // �ŒZ����
        string dirType = "none"; // ����

        foreach (ContactPoint2D contact in other.contacts)
        {
            GameObject otherObject = contact.collider.gameObject; // �Փ˂��Ă���I�u�W�F�N�g
            Vector2 playerPos = transform.position; // �v���C���[�̈ʒu
            Vector2 objectPos = otherObject.transform.position; // �Փ˂��Ă���I�u�W�F�N�g�̈ʒu
            Vector2 dir = objectPos - playerPos; // ����

            // �����̎擾
            if (dir.x != 0.0f && dir.y != 0.0f)
            {
                if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
                { // ���̕����̎擾
                    dirType = dir.x > 0 ? "right" : "left";
                }
                else
                { // �c�̕����̎擾
                    if (dir.y <= 0)
                    {
                        isJumping = false; // �W�����v���Ă��Ȃ���Ԃɂ���
                        dirType = "under";
                    }
                }
            }

            // ��ԋ߂��I�u�W�F�N�g�̍X�V
            float distance = Vector2.Distance(transform.position, otherObject.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = otherObject;
            }
        }

        // �@��
        if (closestObject != null &&
            isDig)
        { // �I�u�W�F�N�g���󂶂�Ȃ��C���@��t���O���^

            // �@��邩�ǂ����̔���
            bool canDig = false;
            string currDigTag = closestObject.tag;
            if (prevDugTag == "none")
            { // �n�߂Č@��
                canDig = true;
            }
            else
            { // �@��̂��n�߂Ă���Ȃ�
                if (prevDugTag == "ou" && currDigTag == "totu")
                { // �O�� "��", ������ "��"
                    canDig = true;
                }
                else if (prevDugTag == "totu" && currDigTag == "ou")
                { // �O�� "��", ������ "��"
                    canDig = true;
                }
            }

            if (canDig)
            { // �@�邱�Ƃ��ł���
                if((dirType == "left" && isDigLeft) ||
                    (dirType == "right" && isDigRight) ||
                    (dirType == "under" && isDigUnder))
				{
                    Dig(closestObject, dirType);
                }
            }
        }
    }

    // �@��
    void Dig(GameObject dugObject, string dirType)
    {
        // �j��
        block bl = dugObject.GetComponent<block>();
        if (bl)
        {
            bl.Deinit(); 
        }
        Destroy(dugObject);
        Debug.Log("�x�����I�u�W�F�N�g: " + dugObject.name);
        Debug.Log(dirType);

        // �x�����^�O�̍X�V
        prevDugTag = dugObject.tag;

        // �X�^�~�i�o�[�����炷
        GameManager.HealthBar.DecHP(1);

        // �X�^�~�i�����炷
        hp -= 1;
    }

#if false
    // Start is called before the first frame update
    void Start()
    {
        // Retrieve all images in DIR_IMAGES
        m_Sprites = Resources.LoadAll<Sprite>(DIR_IMAGES);
        numImages = m_Sprites.Length;
        Debug.Log("#images: " + m_Sprites.Length);
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = m_Sprites[m_index];
    }

    // Update is called once per frame
    void Update()
    {
        float motion = Input.GetAxis("Mouse ScrollWheel");
        if (motion != 0f)
        {
            if (motion > 0f) // forward
            {
                m_index = (m_index + 1) % numImages;
                Debug.Log("m_index: " + m_index);
            }
            else if (motion < 0f) // backwards
            {
                --m_index;
                if (m_index < 0)
                {
                    m_index = numImages - 1;
                }
                Debug.Log("m_index: " + m_index);
            }
            m_SpriteRenderer.sprite = m_Sprites[m_index];
        }
    }
#endif
}
