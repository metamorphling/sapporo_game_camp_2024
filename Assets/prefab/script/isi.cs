using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isi : MonoBehaviour
{
    int HP = 2;
    Animator anim;
    // public plHP plHP;//�v���C���[�̃X�^�~�i
    void Start()
    {
        HP = 2;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            anim.SetTrigger("break");
        }
    }
    void dead()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "dril")//�h�����ɐG�ꂽ��
        {
            HP--;
            /*
           plHP--;//�v���C���[�̃X�^�~�i�����炷
           */
        }

    }
}
