using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [field: SerializeField] public EventReference eventPath { get; private set; }
    //[EventRef][SerializeField] private string ;
    [SerializeField] private Transform soundorigin;
    private void Start()
    {
        GameEvents.current.OnAnimTriggerEnter += PlaySound;
        GameEvents.current.OnSoundTrigger += PlaySound;
    }

    private void PlaySound()
    {
        if (!eventPath.IsNull)
        { 
            Debug.Log("playing sound");
            /*var soundEvent = RuntimeManager.CreateInstance(eventPath);
            soundEvent.set3DAttributes(RuntimeUtils.To3DAttributes(soundorigin.position));*/
            
            /*soundEvent.start();
            soundEvent.release();*/
            
            AudioManager.current.PlayOneShot(FMODEvents.current.bats, soundorigin.position);
            
        }
        else
        {
            Debug.LogWarning("Event path is empty! Please assign a valid FMOD event path.");
        }
    }
    
    private void OnDisable()
    {
        GameEvents.current.OnAnimTriggerEnter -= PlaySound;
        GameEvents.current.OnSoundTrigger -= PlaySound;
    }
}