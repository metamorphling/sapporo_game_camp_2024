using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public Slider slider;
    float maxHP;
    float damade;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = 100.0f;
        damade = 1.0f;
        slider.value = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            DecHP(1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DecHP(2.0f);
        }
    }

    void DecHP(float _damade)
    {
        slider.value -= _damade;
    }
}
