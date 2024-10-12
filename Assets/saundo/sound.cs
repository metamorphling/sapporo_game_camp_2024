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

    [SerializeField] private AudioClip click1sound;
    [SerializeField] private AudioClip jampsund;
    [SerializeField] private AudioClip drillsound;
    [SerializeField] private AudioClip errsound;
    [SerializeField] private AudioClip break1sound;



    public void click()
    {
        click1.PlayOneShot(click1sound);
    }

    public void jamp1()
    {
        jamp.PlayOneShot(jampsund);
    }

    public void drill1()
    {
        drill.PlayOneShot(drillsound);
    }

    public void err1()
    {
        err.PlayOneShot(errsound);
    }

    public void brek()
    {
        break1.PlayOneShot(break1sound);
    }

}
