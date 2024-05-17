using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;


public class TriggerInfo : MonoBehaviour
{
    public MovingCube _platform;

    
    public enum TriggerType
    {
        BATS,
        ROCK
    }

    [SerializeField] private TriggerType triggerType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Platform")
        {
            if (triggerType == TriggerType.BATS)
            {
                _platform.TypeTrigger("Bats");
                
            }

            if (triggerType == TriggerType.ROCK)
            {
                _platform.TypeTrigger("Rock");
            }
        }

        Destroy(this);
    }
}