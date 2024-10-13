using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D = null;         // ����
    public float jumpForce = 5000000000.0f;    // �W�����v��
    bool isJumping = false;             // �W�����v�����ۂ�
    public float walkSpeed = 5000.0f;   // �������x

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

        // �u���b�N�̔j�󏈗�
        //BreakBlock();
    }

    // �ړ�����
    void MoveUpdate()
	{
        float h = Input.GetAxisRaw("Horizontal");           // ���̓��͏��
        float velocityY = this.rigid2D.velocity.y;          // �c�̈ړ���
        Vector2 velocity = new Vector2(0.0f, velocityY);    // �ړ���

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
            localScale.x = h > 0.0f ? absLocalScaleX : absLocalScaleX * -1.0f;
            transform.localScale = localScale;
        }

        // �ړ��ʂ̐ݒ�
        this.rigid2D.velocity = velocity;
    }

    // �W�����v����֐�
    void JumpUpdate()
    {
        if(isJumping)
		{ // ���n���Ă��Ȃ�
            return;
		}

        if (Input.GetKeyDown(KeyCode.W) || 
            Input.GetKeyDown(KeyCode.UpArrow))
		{ // W �L�[�C�������͏���L�[��������
            isJumping = true;  // �W�����v���Ă����Ԃɂ���
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
    }

    // �Փˌ��o����
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("test");

        if (other.gameObject.tag == "ou")
        {
            Debug.Log("��");
        }
        else if (other.gameObject.tag == "totu")
        {
            Debug.Log("��");
        }
    }

    // 2D �I�u�W�F�N�g�Ƃ̓����蔻��̌��o
    void OnCollisionEnter2D(Collision2D other)
    {
        float minDistance = 100000000.0f;   // �ŒZ����
        ContactPoint2D contact2d;           // �ڐG���Ă���I�u�W�F�N�g

        foreach (var contact in other.contacts)
        {
            Vector2 dir = contact.point - (Vector2)transform.position;
            float distance = dir.sqrMagnitude;
            if(distance < minDistance)
			{ // �������̃I�u�W�F�N�g�̕����߂�����
                distance = minDistance;
                contact2d = contact;
            }

            float nor = -contact.normal.sqrMagnitude;
            if (nor < 0.7f)
			{
                isJumping = false;
            }
        }

        // �Փ˂����I�u�W�F�N�g�̃^�O���擾
        if (other.gameObject.tag == "ou")
        {
            Debug.Log("��");
        }
        else if (other.gameObject.tag == "totu")
        {
            Debug.Log("��");
        }
    }

#if false
    // �u���b�N�̔j��
    void BreakBlock()
	{
        if ()
		{

		}
	}
#endif
}
