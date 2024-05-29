using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePreloading : MonoBehaviour
{
    public enum TypeOfSceneManagement
    {
        PRELOAD,
        LOAD
    }

    public TypeOfSceneManagement LoadType;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            if (LoadType == TypeOfSceneManagement.PRELOAD)
            {
                GameManager.Instance.PreloadScene();
            }
            else if (LoadType == TypeOfSceneManagement.LOAD)
            {
                GameManager.Instance.LoadPreloadedScene();
            }
        }
    }
}
