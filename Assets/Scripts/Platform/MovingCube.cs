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

    //TODO: Move this whole logic on TriggerInfo
    

    #region StateInfo

    [HideInInspector] public float currentState;
    private const float STOP = 0;
    private const float CRUISE = 0.5f;
    private const float FREEFALL = 1;

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
    }

    void MoveLift()
    {
        switch (currentState)
        {
            case STOP:
                ApplySpeed(stoppingDeceleration, 0);
                break;
            case CRUISE:
                ApplySpeed(cruisingAcceleration, cruisingTopSpeed);
                break;
            case FREEFALL:
                ApplySpeed(freefallAcceleration, freefallTopSpeed);
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

    //todo: get the stop information from Trigger and not here
    private void Update()
    {
        if (GameManager.Instance.face.transform.position.y <= -23)
        {
            Debug.Log("Enter trigger area");
            GameManager.Instance._xrKnob.value = STOP;
        }
    }

    void FixedUpdate()
    {
        MoveLift();
    }
}