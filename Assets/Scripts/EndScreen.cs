using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public Image WinLoseImage;
    public Sprite WinSprite;
    public Sprite LoseSprite;

    public static bool IsWin = false;

    void Awake()
    {
        WinLoseImage.sprite = IsWin ? WinSprite : LoseSprite;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("strat", LoadSceneMode.Single);
    }
}
