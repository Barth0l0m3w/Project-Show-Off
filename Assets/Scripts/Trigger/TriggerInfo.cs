using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;


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

    public TypeEvent typeEvent;

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
        
        if (typeEvent == TypeEvent.Stop)
        {
            Stop();
        }

        if (typeEvent == TypeEvent.FreeFall)
        {
            FreeFall();
        }

        Destroy(this.GameObject());
    }

    private void FreeFall()
    {
        GameManager.Instance.stateToMoveInto = MovingCube.ElevatorState.FREEFALL;
        GameManager.Instance.SetValue(1);
    }

    private void Stop()
    {
        GameEvents.current.AnimTriggerEnter();
    }
}