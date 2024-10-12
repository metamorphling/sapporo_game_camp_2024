using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AdditiveSceme : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("追加シーンAwake");
        if (Camera.allCamerasCount > 1)
        {
            Camera[] allCameras = Camera.allCameras;
            foreach (Camera cam in allCameras)
            {
                if (cam.gameObject.scene.name != SceneManager.GetActiveScene().name)
                {
                    Destroy(cam.gameObject);
                    break;
                }
            }
        }
        else if (!Camera.main)
        {
            GameObject camera = new GameObject("Main Camera");
            camera.AddComponent<Camera>();
        }

        EventSystem[] EventSystems = FindObjectsOfType<EventSystem>();
        if (EventSystems.Length > 1)
        {
            foreach (EventSystem es in EventSystems)
            {
                if (es.gameObject.scene.name != SceneManager.GetActiveScene().name)
                {
                    Destroy(es.gameObject);
                    break;
                }
            }
        }
        else if (!EventSystem.current)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }
}
