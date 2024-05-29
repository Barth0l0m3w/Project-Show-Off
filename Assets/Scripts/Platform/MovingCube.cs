using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    #region SpeedParameters

    [Header("Speed Parameters")] [SerializeField]
    private float stoppingDeceleration;

    [SerializeField] private float cruisingTopSpeed;
    [SerializeField] private float cruisingAcceleration;
    [SerializeField] private float freefallTopSpeed;
    [SerializeField] private float freefallAcceleration;

    #endregion

    #region StateInfo

    public float leverMovingPoint = 0.9f;

    public enum ElevatorState
    {
        STOP,
        CRUISE,
        FREEFALL
    }

    [HideInInspector] public ElevatorState currentState;
    [HideInInspector] public bool isMoving;
    [HideInInspector] public bool hasEnteredFreeFall;

    #endregion

    #region ToBeRemoved_MoveParams

    [Header("Location to move to")] [SerializeField]
    private Transform mp2;

    private Vector3 p2;
    private Vector3 currentTarget;

    #endregion

    private float currentSpeed = 0;

    // These should be removed when the level is more established
    void Start()
    {
        p2 = mp2.position;
        currentTarget = p2;
        GameEvents.current.OnAnimTriggerEnter += TriggerEnter;
    }

    void MoveLift()
    {
        switch (currentState)
        {
            case ElevatorState.STOP:
                ApplySpeed(stoppingDeceleration, 0);
                isMoving = false;
                hasEnteredFreeFall = false;
                break;
            case ElevatorState.CRUISE:
                ApplySpeed(cruisingAcceleration, cruisingTopSpeed);
                isMoving = true;
                break;
            case ElevatorState.FREEFALL:
                ApplySpeed(freefallAcceleration, freefallTopSpeed);
                isMoving = true;
                break;
        }
    }

    void ApplySpeed(float acceleration, float topSpeed)
    {
        float speedChange = acceleration * Time.deltaTime;

        if (currentSpeed > topSpeed)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, topSpeed, stoppingDeceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, topSpeed, speedChange);
        }

        Vector3 newPosition = Vector3.MoveTowards(transform.position, currentTarget, currentSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    /*private void Update()
    {
        if (!_stop)
        {
            if (GameManager.Instance.face.transform.position.y == -71.7f)
            {
                Debug.Log("Enter trigger area");
                GameManager.Instance._xrKnob.value = 0.09f;
                _stop = true;
            }

            if (GameManager.Instance.face.transform.position.y <= -72f)
            {
                _stop = false;
            }
        }
    }*/

    private void TriggerEnter()
    {
        Debug.Log("Enter trigger area");
        GameManager.Instance._xrKnob.value = 0.09f;
    }

    void FixedUpdate()
    {
        MoveLift();
    }

    private void OnDestroy()
    {
        GameEvents.current.OnAnimTriggerEnter -= TriggerEnter;
    }
}