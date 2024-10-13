using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    public static HPbar HealthBar;
    public static Player PlayerObject;
    public static int JewelCount = 0;
    public static int TreasureCount =  0;

    public static void Update()
    {
#if UNITY_EDITOR // デバッグ
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameManager.HealthBar.DecHP(10);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameManager.HealthBar.RecoveryHP(10);
        }
#endif
        if (SceneManager.GetActiveScene().name == "Main"
        && GameManager.HealthBar
        && GameManager.HealthBar.slider.value <= 0)
        {
            EndScreen.IsWin = false;
            SceneManager.LoadScene("End", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.Escape)
        || Input.GetKeyDown(KeyCode.Pause)
        || Input.GetKeyDown(KeyCode.Backspace))
        {
            Scene scene = SceneManager.GetSceneByName("pause");

            if (!scene.isLoaded)
            {
                SceneManager.LoadScene("pause", LoadSceneMode.Additive);
            }
        }
    }

    public static void Initialize()
    {
        JewelCount = 0;
        TreasureCount = 0;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("シーンをロードした: " + scene.name);
    }
}
