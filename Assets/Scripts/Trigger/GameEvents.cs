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


    public event Action OnStateEnter;

    public void StateTriggerEnter()
    {
        if (OnStateEnter != null)
        {
            OnStateEnter();
        }
    }

    public event Action<int> OnAnimEnter;

    public void AnimTriggerEnter(int id)
    {
        if (OnAnimEnter != null)
        {
            OnAnimEnter(id);
        }
        else
        {
            Debug.LogWarning("No subscribers to OnAnimEnter");
        }
    }

    public event Action<int> OnSoundTrigger;

    public void SoundTriggerEnter(int id)
    {
        if (OnSoundTrigger != null)
        {
            OnSoundTrigger(id);
        }
        else
        {
            Debug.LogWarning("no Subscribers on Sounds");
        }
    }

    public event Action OnFreefallStopTrigger;

    public void OnStopFreefallEnter()
    {
        if (OnFreefallStopTrigger != null)
        {
            OnFreefallStopTrigger();
        }
        else
        {
            Debug.LogWarning("no Subscribers on Sounds");
        }
    }

    public event Action OnDestroyEnter;

    private void OnDestroy()
    {
        if (OnDestroyEnter != null)
        {
            OnDestroyEnter();
        }
        else
        {
            Debug.LogWarning("no Subscribers on Destroy");
        }
    }
}