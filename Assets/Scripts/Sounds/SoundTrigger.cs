using System;
using System.Collections;
using System.Collections.Generic;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class SoundTrigger : MonoBehaviour
{
    [field: SerializeField] public EventReference eventPath { get; private set; }

    [SerializeField] private Transform soundOrigin;
    [SerializeField] private int id;
    [SerializeField] private bool stopPreviousSound;
    //private EventInstance _soundEvent;

    private void Start()
    {
        GameEvents.current.OnSoundTrigger += PlaySound;
    }

    private void PlaySound(int id)
    {
        if (eventPath.IsNull)
        {
            Debug.LogWarning("Event path is empty! Please assign a valid FMOD event path.");
        }
        else if (id == this.id)
        {
            AudioManager.current.PlayOneShot(eventPath, soundOrigin.position, stopPreviousSound);
        }
    }

    private void OnDisable()
    {
        GameEvents.current.OnSoundTrigger -= PlaySound;
    }
}