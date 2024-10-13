using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSceneLoader : MonoBehaviour
{
    public Image fad;

    public void change_button()
    {
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {

        Vector3 current = transform.position;
        Vector3 target = new Vector3(0, -10, 1);
        while (current.x < target.x)
        {
            current = transform.position;
            float time = 10.0f ;
            transform.position = Vector3.MoveTowards(current, target, time);
        }
           
        
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Main");
    }
}
