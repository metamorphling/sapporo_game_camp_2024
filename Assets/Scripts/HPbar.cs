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
     
    }

    //ダメージ
    void DecHP(float _damade)
    {
        slider.value -= _damade;
    }

    //回復recovery
    void RecoveryHP(float _recovery)
    {
        slider.value += _recovery;
    }
}
