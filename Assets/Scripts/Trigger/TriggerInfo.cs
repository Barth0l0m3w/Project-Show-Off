using Unity.VisualScripting;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Serialization;

public class TriggerInfo : MonoBehaviour
{
    private bool _hasTriggered;
    [SerializeField] private int triggerId;

    public enum TypeEvent
    {
        Stop,
        FreeFall,
        SoundEffect,
        StopSoundEffect,
        Animation
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
        if(typeEvent != TypeEvent.FreeFall)_hasTriggered = true;

        if (typeEvent == TypeEvent.Stop)
        {
            GameEvents.current.AnimTriggerEnter(triggerId);
            GameEvents.current.StateTriggerEnter();
            //GameEvents.current.StopSoundTriggerEnter();
            GameEvents.current.SoundTriggerEnter(triggerId);
        }

        if (typeEvent == TypeEvent.FreeFall)
        {
            GameManager.Instance.stateToMoveInto = MovingCube.ElevatorState.FREEFALL;
            GameManager.Instance.platform.hasEnteredFreeFall = true;
            GameManager.Instance.SetValue(1);
            //GameEvents.current.StopSoundTriggerEnter();
            GameEvents.current.SoundTriggerEnter(triggerId);
        }

        if (typeEvent == TypeEvent.SoundEffect)
        {
            //GameEvents.current.StopSoundTriggerEnter();
            GameEvents.current.SoundTriggerEnter(triggerId);
        }
        if (typeEvent == TypeEvent.StopSoundEffect)
        {
            //GameEvents.current.StopSoundTriggerEnter();
        }
        if (typeEvent == TypeEvent.Animation)
        {
            //GameEvents.current.StopSoundTriggerEnter();
            GameEvents.current.SoundTriggerEnter(triggerId);
            GameEvents.current.AnimTriggerEnter(triggerId);
        }

        if(typeEvent != TypeEvent.FreeFall) Destroy(this.GameObject());
    }

    //todo: is this being used? 
    /*private void FreeFall()
    {
        GameManager.Instance.stateToMoveInto = MovingCube.ElevatorState.FREEFALL;
        GameManager.Instance.platform.hasEnteredFreeFall = true;
        GameManager.Instance.SetValue(1);
    }*/

    //why is this here? its not being called, todo: cleanup
    private void Stop()
    {
        GameEvents.current.AnimTriggerEnter(triggerId);
        GameEvents.current.SoundTriggerEnter(triggerId);
    }
}