using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("bats SFX")]
    [field: SerializeField] public EventReference bats { get; private set; }
    public static FMODEvents current { get; private set; }

    private void Awake()
    {
        if (current != null)
        {
            Debug.LogWarning("found more then one FMOD events current in the scene");
        }

        current = this;
    }
}