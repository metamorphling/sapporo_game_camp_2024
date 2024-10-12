using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{

    [SerializeField] private AudioSource click1;
    [SerializeField] private AudioSource jamp;
    [SerializeField] private AudioSource drill;
    [SerializeField] private AudioSource err;
    [SerializeField] private AudioSource break1;
    [SerializeField] private AudioSource attak;
    [SerializeField] private AudioSource kria;
    [SerializeField] private AudioSource over;

    [SerializeField] private AudioClip click1sound;
    /*[SerializeField] private AudioClip jampsund;
    [SerializeField] private AudioClip drillsound;
    [SerializeField] private AudioClip errsound;
    [SerializeField] private AudioClip break1sound;
    [SerializeField] private AudioClip attaksound;
    [SerializeField] private AudioClip kriasound;
    [SerializeField] private AudioClip oversound;*/


    void Start()
    {
        drill1();
    }

    public void click()//ボタンクリック
    {
        click1.PlayOneShot(click1sound);
    }

    public void jamp1()//ジャンプ
    {
        jamp.PlayOneShot(click1sound);
    }

    public void drill1()//攻撃（接触）
    {
        drill.PlayOneShot(click1sound);
    }

    public void err1()//壊せない
    {
        err.PlayOneShot(click1sound);
    }

    public void brek()//ブロック破壊
    {
        break1.PlayOneShot(click1sound);
    }
    public void attakku1()//岩石一回目
    {
        attak.PlayOneShot(click1sound);
    }

    public void kria1()//ゲームクリア
    {
        kria.PlayOneShot(click1sound);
    }

    public void over1()//ゲームオーバー
    {
        over.PlayOneShot(click1sound);
    }
}
