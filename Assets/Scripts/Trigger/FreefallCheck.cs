using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreefallCheck : MonoBehaviour
{
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
        gameObject.SetActive(false);
    }
}
