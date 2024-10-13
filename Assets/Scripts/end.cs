using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EndGameBottan();
    }
    public void EndGame()
    {

        sound snd = FindObjectOfType<sound>();
        if (snd)
        {
            snd.click();
        }

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
        Application.Quit();//�Q�[���v���C�I��
#endif
    }
    private void EndGameBottan()
    {
        //Esc�������ꂽ��
        if (Input.GetKey(KeyCode.Backspace))
        {

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
            Application.Quit();//�Q�[���v���C�I��
#endif
        }

    }
}
