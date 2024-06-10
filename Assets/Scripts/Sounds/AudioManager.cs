using System;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    public static AudioManager current { get; private set; }

    private EventInstance _currentSound;
    

    private void Awake()
    {
        if (current != null)
        {
            Debug.LogWarning("found more then one sound Manager in the scene");
        }

        current = this;
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos, bool stopPreviousSound)
    {
        if (stopPreviousSound)
        {
            if (_currentSound.isValid())
            {
                _currentSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                _currentSound.release();
            }
        }

        _currentSound = RuntimeManager.CreateInstance(sound);
        _currentSound.set3DAttributes(RuntimeUtils.To3DAttributes(worldPos));
        
        _currentSound.start();
        _currentSound.release();
    }
}