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
    [SerializeField] private AudioClip jampsund;
    [SerializeField] private AudioClip drillsound;
    [SerializeField] private AudioClip errsound;
    [SerializeField] private AudioClip break1sound;
    [SerializeField] private AudioClip attaksound;
    [SerializeField] private AudioClip kriasound;
    [SerializeField] private AudioClip oversound;

    public void click()//�{�^���N���b�N
    {
        click1.PlayOneShot(click1sound);
    }

    public void jamp1()//�W�����v
    {
        jamp.PlayOneShot(jampsund);
    }

    public void drill1()//�U���i�ڐG�j
    {
        drill.PlayOneShot(drillsound);
    }

    public void err1()//�󂹂Ȃ�
    {
        err.PlayOneShot(errsound);
    }

    public void brek()//�u���b�N�j��
    {
        break1.PlayOneShot(break1sound);
    }
    public void attakku1()//��Έ���
    {
        attak.PlayOneShot(attaksound);
    }

    public void kria1()//�Q�[���N���A
    {
        kria.PlayOneShot(kriasound);
    }

    public void over1()//�Q�[���I�[�o�[
    {
        over.PlayOneShot(oversound);
    }
}
