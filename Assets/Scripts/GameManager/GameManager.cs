using System;
using System.Collections;
using System.Collections.Generic;
using Udar.SceneManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;
using XRKnob = Unity.VRTemplate.XRKnob;

public class GameManager : MonoBehaviour
{
    public MovingCube platform;
    public Transform player;
    public XRKnob _xrKnob;
    public XRLever _Lever;
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
        //DontDestroyOnLoad(gameObject);
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
    
    
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void LoadSpecificScene()
    {
        SceneManager.LoadScene(0);

    }

    public void LoadSpecificScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
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
        _Lever.enabled = !_Lever.enabled;
    }

    public void SwitchLeverState()
    {
        bool currentLeverState = _Lever.value;
        _Lever.value = !currentLeverState;
    }

    public void SetElevatorCruising()
    {
        platform.currentState = MovingCube.ElevatorState.CRUISE;
    }

    public void SetElevatorForceStop()
    {
        platform.currentState = MovingCube.ElevatorState.STOP;
    }
    
    public void SetCruisingSpeed(float newSpeed)
    {
        platform.cruisingTopSpeed = newSpeed;
    }

    public void SetCruisingAcceleration(float newSpeed)
    {
        platform.cruisingAcceleration = newSpeed;
    }
    
    public void SetDeceleration(float newDec)
    {
        platform.stoppingDeceleration = newDec;
    }
    
    public void EventDebug()
    {
        Debug.Log("Rowan is so sexy uwu");
    }

    public void HandleLeverGrabGFX(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            controllerInteractor.gameObject.GetComponentInParent<HandModelCont>().ToggleGFX();
        }
    }

    public void TeleportPlayer(Transform newPosition)
    {
        player.SetParent(null);
        player.position = newPosition.position;
        player.rotation = newPosition.rotation;
    }
    
}
