using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //[SerializeField] Button button;

    public Canvas canvas;            // Canvas���A�T�C��
    public GameObject[] uiElements; // ButtonUI���i�[����z��
    private bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {

        // ������Ԃł͂��ׂĂ�UI�v�f���\���ɂ���
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �^�u�L�[�������ꂽ�����`�F�b�N
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // �\����Ԃ�؂�ւ���
            isVisible = !isVisible;

            // Canvas����A�N�e�B�u�Ȃ�A�N�e�B�u�ɂ���
            if (!canvas.gameObject.activeSelf)
            {
                canvas.gameObject.SetActive(true);
            }

            // �\����Ԃɉ����Ă��ׂĂ�UI�v�f�̕\����؂�ւ���
            foreach (GameObject uiElement in uiElements)
            {
                uiElement.SetActive(isVisible);
            }

          
        }
    }

    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void ClickContenue()
    {
        Debug.Log("contenue!");  // ���O���o��
    }

    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void ClickRetry()
    {
        Debug.Log("retry!");  // ���O���o��
    }

    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void ClickQuit()
    {
        Debug.Log("quit!");  // ���O���o��
    }
}
