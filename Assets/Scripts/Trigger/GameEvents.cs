using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;


    private void Awake()
    {
        current = this;
    }


    public event Action OnAnimTriggerEnter;
    public event Action OnDestroyEnter;
    public event Action OnFreefallStop;

    public void AnimTriggerEnter()
    {
        if (OnAnimTriggerEnter != null)
        {
            OnAnimTriggerEnter();
        }
        else
        {
            Debug.LogWarning("No subscribers to OnAnimTriggerEnter");
        }
    }

    public event Action Sounds;

    public void SoundTrigger()
    {
        if (Sounds != null)
        {
            Sounds();
        }
        else
        {
            Debug.LogWarning("no Subscribers on Sounds");
        }
    }

    public void StopFreefall()
    {
        if(OnFreefallStop != null) OnFreefallStop();
        
    }
    
    private void OnDestroy()
    {
        if(OnDestroyEnter != null) OnDestroyEnter();
    }
}