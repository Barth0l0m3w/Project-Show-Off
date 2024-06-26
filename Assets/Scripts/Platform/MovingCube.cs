using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    #region SpeedParameters

    [Header("Speed Parameters")] 
    public float stoppingDeceleration;
    public float cruisingTopSpeed;
    public float cruisingAcceleration;
    public float freefallTopSpeed;
    public float freefallAcceleration;
    [SerializeField] private List<ParticleSystem> brakeSparks;

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

    #region MoveParams
    
    [Header("Location to move to")] [SerializeField]
    private Transform mp2;

    private Vector3 p2;
    private Vector3 currentTarget;

    #endregion

    private float currentSpeed = 0;
    private static MovingCube Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        
    }

    // These should be removed when the level is more established
    void Start()
    {
        p2 = mp2.position;
        currentTarget = p2;
        GameEvents.current.OnStateEnter += Enter;
        //GameEvents.current.OnDestroyEnter += StopListening; todo: this function can be gone right? 
        GameEvents.current.OnCheckpointTeleport += hasTeleported;
    }

    void MoveLift()
    {
        switch (currentState)
        {
            case ElevatorState.STOP:
                ApplySpeed(stoppingDeceleration, 0);
                isMoving = false;
                if (currentSpeed > 0)
                {
                    StartCoroutine(GameManager.Instance.TriggerHaptics(1f, 0.1f, 0.1f));
                    foreach (var particle in brakeSparks)
                    {
                        particle.Play();
                    }
                    //todo: play the stopping sound
                    
                }
                else if (currentSpeed <= 0)
                {
                    foreach (var particle in brakeSparks)
                    {
                        particle.Stop();
                    }
                }

                if (hasEnteredFreeFall)
                {
                    hasEnteredFreeFall = false;
                    GameEvents.current.OnStopFreefallEnter();
                }

                break;
            case ElevatorState.CRUISE:
                ApplySpeed(cruisingAcceleration, cruisingTopSpeed);
                isMoving = true;
                break;
            case ElevatorState.FREEFALL:
                ApplySpeed(freefallAcceleration, freefallTopSpeed);
                GameManager.Instance.TriggerHaptics(0.8f, 0.1f);
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

    void hasTeleported()
    {
        Debug.Log("Has teleported");
        hasEnteredFreeFall = false;
        currentState = ElevatorState.CRUISE;
        GameManager.Instance._xrKnob.enabled = true;
        GameManager.Instance._Lever.enabled = true;
        currentSpeed = cruisingTopSpeed;
    }

//todo: naming convention, what does this do? 
    private void Enter()
    {
        Debug.Log("Enter trigger area");
        GameManager.Instance._Lever.value = false;
    }

    private void StopListening()
    {
        GameEvents.current.OnStateEnter -= Enter;
        //GameEvents.current.OnDestroyEnter -= StopListening;
    }

    void FixedUpdate()
    {
        MoveLift();
    }

    private void OnDestroy()
    {
        GameEvents.current.OnStateEnter -= Enter;
    }
}