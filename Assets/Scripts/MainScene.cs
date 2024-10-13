using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    void Awake()
    {
        sound snd = FindObjectOfType<sound>();
        if (snd)
        {
            snd.bgm2();
        }

        GameManager.Initialize();

        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        SceneManager.LoadScene("Background", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        SceneManager.LoadScene("Block", LoadSceneMode.Additive);
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        yield return null;
    }

    void Update()
    {
        GameManager.Update();
    }
}
