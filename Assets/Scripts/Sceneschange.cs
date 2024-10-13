using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Sceneschange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void change_button()
    {

        StartCoroutine("a");


    }
    private IEnumerator a()
    {
        FindObjectOfType<sound>().click();
    yield return new WaitForSeconds(1);
    SceneManager.LoadScene("Main");

    }
}