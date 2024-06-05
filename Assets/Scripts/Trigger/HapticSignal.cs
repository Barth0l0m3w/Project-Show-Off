using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticSignal : MonoBehaviour
{
    [Header("Controller refferences")] 
    [SerializeField] private XRBaseController leftController;
    [SerializeField] private XRBaseController rightController;
    
    [Header("Haptics values")]
    [Range(0,1)]
    [SerializeField] private float intensity;
    [SerializeField] private float duration;

    public void TriggerHaptics()
    {
        if (intensity > 0)
        {
            leftController.SendHapticImpulse(intensity, duration);
            rightController.SendHapticImpulse(intensity, duration);
        }
    }
    
    public void TriggerHaptics(float intens, float dur)
    {
        if (intensity > 0)
        {
            leftController.SendHapticImpulse(intens, dur);
            rightController.SendHapticImpulse(intens, dur);
        }
    }
}
