using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MovingCube platform;
    public XRKnob _xrKnob;
    public GameObject face;
    public MovingCube.ElevatorState stateToMoveInto;
    
    public static GameManager Instance;

    private float value;
    
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
        
    }
    
    void Start()
    {
        SetValue(_xrKnob.value);
    }

    //TODO: Remove later as it doesn't show up on VR screen
    #if UNITY_EDITOR
    private void OnGUI()
    {
        GUI.Label(new Rect(new Vector2(0,0), new Vector2(200, 200)), "The value is: " + value);
    }
    #endif

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
}
