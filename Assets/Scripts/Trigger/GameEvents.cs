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

    public event Action OnAnimTriggerEnter;

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

    public event Action<int> OnSoundTrigger;

    public void OnSoundTriggerEnter(int id)
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

    public event Action OnFreefallStop;

    public void StopFreefall()
    {
        if (OnFreefallStop != null) OnFreefallStop();
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