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

    private Vector3 soundpos;

    private EventInstance soundEvent;

    private void Start()
    {
        GameEvents.current.OnSoundTrigger += PlaySound;
    }

//todo: setter for the soundpos soundmanager can use a getter and in the update annotate the sounds in update with. 

    private void Update()
    {
        soundpos = soundOrigin.position;
    }

    private void PlaySound(int id)
    {
        if (eventPath.IsNull)
        {
            Debug.LogWarning("Event path is empty! Please assign a valid FMOD event path.");
        }
        else if (id == this.id)
        {
            //Debug.Log("playing sound" + eventPath + stopPreviousSound);

            AudioManager.current.PlayOneShot(eventPath, soundOrigin.position, stopPreviousSound);
        }

        /*else
        {
            Debug.LogWarning("Event path is empty! Please assign a valid FMOD event path.");
        }*/
    }

    private void OnDisable()
    {
        GameEvents.current.OnSoundTrigger -= PlaySound;
    }
}