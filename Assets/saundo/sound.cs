using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sound : MonoBehaviour
{

    [SerializeField] private AudioSource click1;
    [SerializeField] private AudioSource sound1;
    /*[SerializeField] private AudioSource drill;
    [SerializeField] private AudioSource err;
    [SerializeField] private AudioSource break1;
    [SerializeField] private AudioSource attak;
    [SerializeField] private AudioSource kria;
    [SerializeField] private AudioSource over;*/

    [SerializeField] private AudioClip click1sound;
    [SerializeField] private AudioClip jampsund;
    [SerializeField] private AudioClip drillsound;
    [SerializeField] private AudioClip errsound;
    [SerializeField] private AudioClip break1sound;
    [SerializeField] private AudioClip attaksound;
    [SerializeField] private AudioClip kriasound;
    [SerializeField] private AudioClip oversound;
    [SerializeField] private AudioClip bgm1sound;
    [SerializeField] private AudioClip bgm2sound;


 public bool DontDestroyEnabled = true;

    void Start()
    {
        bgm1();
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);

        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void click()//ボタンクリック
    {
        click1.PlayOneShot(click1sound);
    }

    public void jamp1()//ジャンプ
    {
        click1.PlayOneShot(jampsund);
    }

    public void drill1()//攻撃（接触）
    {
        click1.PlayOneShot(drillsound);
    }

    public void err1()//壊せない
    {
        click1.PlayOneShot(errsound);
    }

    public void brek()//ブロック破壊
    {
        click1.PlayOneShot(break1sound);
    }
    public void attakku1()//岩石一回目
    {
        click1.PlayOneShot(attaksound);
    }

    public void kria1()//ゲームクリア
    {
        click1.PlayOneShot(kriasound);
    }

    public void over1()//ゲームオーバー
    {
        click1.PlayOneShot(oversound);
    }
    public void bgm1()//bgm1
    {
        sound1.PlayOneShot(bgm1sound);
    }
    public void bgm2()//bgm2
    {
        sound1.PlayOneShot(bgm2sound);
    }
}
