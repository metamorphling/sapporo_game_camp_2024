using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ganseki : MonoBehaviour
{
    int HP = 2;
    Animator anim;
    void Start()
    {
        HP = 2;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP != 2)
        {
            anim.SetBool("hibi", true);
        }
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
        if (col.gameObject.tag == "dril")//ƒhƒŠƒ‹‚ÉG‚ê‚½Žž
        {
            HP--;
        }
    }
}
