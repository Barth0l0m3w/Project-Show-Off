using System;
using System.Collections;
using System.Collections.Generic;
using Udar.SceneManager;
using UnityEngine;

public class FreefallCheck : MonoBehaviour
{
    [Header("Tick if transition at this level end")]
    [SerializeField] private bool replacesScene;
    [SerializeField] private SceneField replacementScene;
    
    private void Start()
    {
        GameEvents.current.OnFreefallStop += SuccesfullStop;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Platform")) GameManager.Instance._xrKnob.enabled = false;
        
    }

    void SuccesfullStop()
    {
        if (replacesScene)
        {
            //GameManager.Instance.sceneToLoad = replacementScene;
        }
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameEvents.current.OnFreefallStop -= SuccesfullStop;
    }
}
