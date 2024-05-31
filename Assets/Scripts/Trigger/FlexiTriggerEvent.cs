using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlexiTriggerEvent : MonoBehaviour
{
    [Serializable]
    [Tooltip("Drag in any scripts here that you want to trigger upon entering this parent's area")]
    public class TriggerEnteredEvent : UnityEvent<float> { }

    [SerializeField]
    [Tooltip("Event to trigger on trigger enter")]
    TriggerEnteredEvent m_TriggerEntered = new TriggerEnteredEvent();

    public TriggerEnteredEvent triggerEntered => m_TriggerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            m_TriggerEntered.Invoke(0);
        }
    }
}
