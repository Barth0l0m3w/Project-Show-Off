using System;
using System.Collections;
using System.Collections.Generic;
using Udar.SceneManager;
using UnityEngine;

public class FreefallCheck : MonoBehaviour
{

    private void Start()
    {
        GameEvents.current.OnFreefallStopTrigger += SuccesfullStopTrigger;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            //GameManager.Instance._xrKnob.enabled = false;
            GameManager.Instance._Lever.enabled = false;
        }
        
    }

    void SuccesfullStopTrigger()
    {
        GameManager.Instance.SwitchLeverState();
        GameManager.Instance.platform.currentState = MovingCube.ElevatorState.CRUISE;
        GameManager.Instance.ToggleLever();
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameEvents.current.OnFreefallStopTrigger -= SuccesfullStopTrigger;
    }
}
