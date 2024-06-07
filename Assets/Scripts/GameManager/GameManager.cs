using System;
using System.Collections;
using System.Collections.Generic;
using Udar.SceneManager;
using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class GameManager : MonoBehaviour
{
    public MovingCube platform;
    public XRKnob _xrKnob;
    public CanvasGroup fadeScreen;
    public MovingCube.ElevatorState stateToMoveInto;

    
    public static GameManager Instance;

    private float value;
    private HapticSignal haptics;
    private bool isVibrating;

    

    void Start()
    {
        haptics = GetComponent<HapticSignal>();
    }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
    }
    
    public void SetValue(float pValue)
    {
        value = pValue;
        if (value < platform.leverMovingPoint)
        {
            platform.currentState = MovingCube.ElevatorState.STOP;
        }
        else
        {
            platform.currentState = stateToMoveInto;
        }
    }

    void Update()
    {
        if (platform.hasEnteredFreeFall)
        {
            stateToMoveInto = MovingCube.ElevatorState.FREEFALL;
        }
        else
        {
            stateToMoveInto = MovingCube.ElevatorState.CRUISE;
        }
    }

    // public void ResetElevator()
    // {
    //     platform.transform.position = ElevatorDataContainer.Instance.startData.location;
    //     platform.currentState = ElevatorDataContainer.Instance.startData.state;
    // }
    
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //ResetElevator();
    }

    public void LoadSpecificScene()
    {
        SceneManager.LoadScene(0);
        //ResetElevator();
    }

    public void LoadSpecificScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        //ResetElevator();
    }

    public void TriggerHaptics()
    {
        haptics.TriggerHaptics();
    }

    public void TriggerHaptics(float intensity, float duration)
    {
        haptics.TriggerHaptics(intensity, duration);
    }
    
    public IEnumerator TriggerHaptics(float inty, float dur, float spacing)
    {
        if (!isVibrating)
        {
            isVibrating = true;
            haptics.TriggerHaptics(inty, dur);
            yield return new WaitForSeconds(spacing);
            isVibrating = false;
        }
    }

    public void ToggleLever()
    {
        _xrKnob.enabled = !_xrKnob.enabled;
    }
}
