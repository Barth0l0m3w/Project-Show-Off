using Unity.VisualScripting;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Serialization;

public class TriggerInfo : MonoBehaviour
{
    private bool _hasTriggered;
    [SerializeField] private int soundId;

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
            GameEvents.current.OnSoundTriggerEnter(soundId);
        }

        if (typeEvent == TypeEvent.FreeFall)
        {
            GameManager.Instance.stateToMoveInto = MovingCube.ElevatorState.FREEFALL;
            GameManager.Instance.SetValue(1);
            GameEvents.current.OnSoundTriggerEnter(soundId);
        }

        if (typeEvent == TypeEvent.SoundEffect)
        {
            GameEvents.current.OnSoundTriggerEnter(soundId);
        }
        
        Destroy(this.GameObject());
    }

    private void FreeFall()
    {
        GameManager.Instance.stateToMoveInto = MovingCube.ElevatorState.FREEFALL;
        GameManager.Instance.platform.hasEnteredFreeFall = true;
        GameManager.Instance.SetValue(1);
    }

    private void Stop()
    {
        GameEvents.current.AnimTriggerEnter();
        GameEvents.current.OnSoundTriggerEnter(soundId);
    }
}