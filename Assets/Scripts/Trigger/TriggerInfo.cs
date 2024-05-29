using System;
using Unity.VisualScripting;
using UnityEngine;


//triggering 
public class TriggerInfo : MonoBehaviour
{
    private bool _hasTriggered;
    
    public enum TypeEvent
    {
        Stop,
        FreeFall,
        CheckPoint,
        SoundEffect,
    }

    private void Start()
    {
        TypeEvent typeEvent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_hasTriggered) return; //flag

        OnEnter();
    }

    private void OnEnter()
    {
        _hasTriggered = true;

        GameEvents.current.AnimTriggerEnter();
        
        Destroy(this.GameObject());
    }
}