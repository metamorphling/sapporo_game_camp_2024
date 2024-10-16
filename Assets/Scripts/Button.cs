using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    //[SerializeField] Button button;

    public Canvas canvas;            // Canvasをアサイン
    public GameObject[] uiElements; // ButtonUIを格納する配列
    private bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {

        // 初期状態ではすべてのUI要素を非表示にする
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // タブキーが押されたかをチェック
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 表示状態を切り替える
            isVisible = !isVisible;

            // Canvasが非アクティブならアクティブにする
            if (!canvas.gameObject.activeSelf)
            {
                canvas.gameObject.SetActive(true);
            }

            // 表示状態に応じてすべてのUI要素の表示を切り替える
            foreach (GameObject uiElement in uiElements)
            {
                uiElement.SetActive(isVisible);
            }

          
        }
    }

    // ボタンが押された場合、今回呼び出される関数
    public void ClickContenue()
    {
        Debug.Log("contenue!");  // ログを出力

SceneManager.UnloadSceneAsync("pause");
    }

    // ボタンが押された場合、今回呼び出される関数
    public void ClickRetry()
    {
        Debug.Log("retry!");  // ログを出力
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    // ボタンが押された場合、今回呼び出される関数
    public void ClickQuit()
    {
        Debug.Log("quit!");  // ログを出力
        SceneManager.LoadScene("strat", LoadSceneMode.Single);
    }
}
