using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    public static HPbar HealthBar;
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
            SceneManager.LoadScene("End", LoadSceneMode.Single);
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
