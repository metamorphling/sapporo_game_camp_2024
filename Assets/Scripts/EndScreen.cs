using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public Image WinLoseImage;
    public Sprite WinSprite;
    public Sprite LoseSprite;

    public TextMeshProUGUI Jewelry, Treasure;

    public static bool IsWin = false;

    void Awake()
    {
        WinLoseImage.sprite = IsWin ? WinSprite : LoseSprite;
        Jewelry.text = $"x {GameManager.JewelCount}";
        Treasure.text = $"x {GameManager.TreasureCount}";
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
