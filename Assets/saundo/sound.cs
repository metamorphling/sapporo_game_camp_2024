using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class sound : MonoBehaviour
{

    [SerializeField] private AudioSource click1;
    /*[SerializeField] private AudioSource jamp;
    [SerializeField] private AudioSource drill;
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
        


        if (DontDestroyEnabled)
        {
            // Scene��J�ڂ��Ă��I�u�W�F�N�g�������Ȃ��悤�ɂ���
            DontDestroyOnLoad(this);
        }
    }

    public void click()//�{�^���N���b�N
    {
        click1.PlayOneShot(click1sound);
    }

    public void jamp1()//�W�����v
    {
        click1.PlayOneShot(jampsund);
    }

    public void drill1()//�U���i�ڐG�j
    {
        click1.PlayOneShot(drillsound);
    }

    public void err1()//�󂹂Ȃ�
    {
        click1.PlayOneShot(errsound);
    }

    public void brek()//�u���b�N�j��
    {
        click1.PlayOneShot(break1sound);
    }
    public void attakku1()//��Έ���
    {
        click1.PlayOneShot(attaksound);
    }

    public void kria1()//�Q�[���N���A
    {
        click1.PlayOneShot(kriasound);
    }

    public void over1()//�Q�[���I�[�o�[
    {
        click1.PlayOneShot(oversound);
    }
    public void bgm1()//bgm1
    {
        click1.PlayOneShot(bgm1sound);
    }
    public void bgm2()//bgm2
    {
        click1.PlayOneShot(bgm2sound);
    }
}
