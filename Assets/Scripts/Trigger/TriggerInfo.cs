using Unity.VisualScripting;
using UnityEngine;
using NaughtyAttributes;

public class TriggerInfo : MonoBehaviour
{
    private bool _hasTriggered;

    public enum TypeEvent
    {
        Stop,
        FreeFall,
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
    
    [Button]
    private void OnEnter()
    {
        _hasTriggered = true;

        if (typeEvent == TypeEvent.Stop)
        {
            GameEvents.current.AnimTriggerEnter();
        }

        if (typeEvent == TypeEvent.FreeFall)
        {
            GameManager.Instance.stateToMoveInto = MovingCube.ElevatorState.FREEFALL;
            GameManager.Instance.SetValue(1);
        }

        if (typeEvent == TypeEvent.SoundEffect)
        {
            GameEvents.current.OnSoundTriggerEnter();
        }

        Destroy(this.GameObject());
    }
}