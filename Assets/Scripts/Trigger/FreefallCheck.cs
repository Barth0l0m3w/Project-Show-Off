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
        GameEvents.current.OnFreefallStopTrigger += SuccesfullStopTrigger;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Platform")) GameManager.Instance._xrKnob.enabled = false;
        
    }

    void SuccesfullStopTrigger()
    {
        if (replacesScene)
        {
            GameManager.Instance.sceneToLoad = replacementScene;
        }
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameEvents.current.OnFreefallStopTrigger -= SuccesfullStopTrigger;
    }
}
