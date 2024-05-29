using System;
using Unity.VisualScripting;
using UnityEngine;


//triggering 
public class TriggerInfo : MonoBehaviour
{
    private bool _hasTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (_hasTriggered) return;

        OnEnter();
    }

    private void OnEnter()
    {
        _hasTriggered = true;

        GameEvents.current.BatTriggerEnter();
        
        Destroy(this.GameObject());
    }
}