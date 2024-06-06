using System.Collections.Generic;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class SoundTrigger : MonoBehaviour
{
    [field: SerializeField] public EventReference eventPath { get; private set; }
    [SerializeField] private Transform soundOrigin;
    [SerializeField] private int id;
    private bool _isPlayingSound = false;
    private EventInstance soundEvent;

    private Queue<EventReference> soundQueue = new Queue<EventReference>();
    private EventInstance currentSoundEvent;

    private void Start()
    {
        GameEvents.current.OnSoundTrigger += PlaySound;
        
    }

    private void PlaySound(int id)
    {
        if (id == this.id)
        {
            
            Debug.Log("playing sound");
            soundEvent = RuntimeManager.CreateInstance(eventPath);
            soundEvent.set3DAttributes(RuntimeUtils.To3DAttributes(soundOrigin.position));
            soundEvent.start();
            soundEvent.release();
            
            //AudioManager.current.PlayOneShot(FMODEvents.current.bats, soundOrigin.position);
        }

        else
        {
            Debug.LogWarning("Event path is empty! Please assign a valid FMOD event path.");
        }
    }
    
    // todo: call it from an event that is placed om the trigger, it calls when a new trigger is hit
    private void StopSound()
    {
        soundEvent.stop(STOP_MODE.ALLOWFADEOUT);
    }

    private void OnDisable()
    {
        GameEvents.current.OnSoundTrigger -= PlaySound;
    }
}