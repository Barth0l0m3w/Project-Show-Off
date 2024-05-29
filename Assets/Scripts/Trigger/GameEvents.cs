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

    
    
    private void OnDestroy()
    {
        if(OnDestroyEnter != null) OnDestroyEnter();
    }
}