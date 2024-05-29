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


    public event Action OnBatTriggerEnter;

    public void BatTriggerEnter()
    {
        if (OnBatTriggerEnter != null)
        {
            OnBatTriggerEnter();
        }
        else
        {
            Debug.LogWarning("No subscribers to OnBatTriggerEnter");
        }
    }
}