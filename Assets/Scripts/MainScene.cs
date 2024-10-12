using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    void Awake()
    {
        GameManager.Initialize();

        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        SceneManager.LoadScene("Background", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        SceneManager.LoadScene("Block", LoadSceneMode.Additive);
        SceneManager.LoadScene("Foreground2", LoadSceneMode.Additive);
        yield return null;
    }
}
