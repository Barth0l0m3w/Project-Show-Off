using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Management;
using UnityEngine.Rendering;
using UnityEngine.AdaptivePerformance;


public class VRSettingInitializer : MonoBehaviour
{
    private float targetFrameRate = 72.0f; 
    [SerializeField]private float minResolutionScale = 0.5f;
    [SerializeField] private float shadowsDistance = 15f;
    private float maxResolutionScale = 1.0f;
    
    private IAdaptivePerformance ap;
    

    void Start()
    {
        ap = Holder.Instance;
        if (ap == null) {
            Debug.LogError("Adaptive Performance not initialized.");
            return;
        }

        ap.DevicePerformanceControl.CpuLevel = 2;
        ap.DevicePerformanceControl.GpuLevel = 2;


        QualitySettings.shadowDistance = shadowsDistance; 
        QualitySettings.antiAliasing = 2; 
        Application.targetFrameRate = 72; 
    }


    void Update()
    {
        float currentFrameTime = Time.deltaTime;
        
        if (currentFrameTime > 1.0f / targetFrameRate) {
            XRSettings.eyeTextureResolutionScale = Mathf.Max(minResolutionScale, XRSettings.eyeTextureResolutionScale - 0.01f);
        } else {
            XRSettings.eyeTextureResolutionScale = Mathf.Min(maxResolutionScale, XRSettings.eyeTextureResolutionScale + 0.01f);
        }
    }
}
