using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager current { get; private set; }

    private void Awake()
    {
        if (current != null)
        {
            Debug.LogWarning("found more then one sound Manager in the scene");
        }

        current = this;
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}