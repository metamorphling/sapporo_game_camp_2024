using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class block : MonoBehaviour
{
    public GameObject ItemSpawnOnDestroy;

    protected void Start()
    {
    }

    protected void Update()
    {
    }

    protected virtual void OnDestroy()
    {
#if UNITY_EDITOR
    if (EditorApplication.isPlayingOrWillChangePlaymode || (Application.isPlaying && !Application.isEditor))
    {
        return;
    }
#endif
    }

    public void Deinit()
    {
        float randomValue = Random.Range(0f, 100f);
        if (dropitem.CanSpawn(randomValue))
        {
            Instantiate(ItemSpawnOnDestroy, this.transform.position, this.transform.rotation);
        }
    }
}
