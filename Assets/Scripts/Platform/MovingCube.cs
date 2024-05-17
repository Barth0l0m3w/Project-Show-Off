using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    #region SpeedParameters
    [Header("Speed Parameters")]
    [SerializeField]private float stoppingDeceleration;
    [SerializeField]private float cruisingTopSpeed;
    [SerializeField]private float cruisingAcceleration;
    [SerializeField]private float freefallTopSpeed;
    [SerializeField]private float freefallAcceleration;
    #endregion

    //TODO: Move this whole logic on TriggerInfo
    #region Refferences
    [Header("Object Refferences")]
    [SerializeField] private GameObject batsPrefab;
    [SerializeField] private GameObject rocksPrefab;
    [SerializeField] private GameObject playerCamera;
    
    public Vector3 batsSpawnOffset;
    public Vector3 rocksSpawnOffset;
    #endregion
    
    #region StateInfo
    [HideInInspector]public float currentState;
    private const float STOP = 0;
    private const float CRUISE = 0.5f;
    private const float FREEFALL = 1;
    #endregion

    #region ToBeRemoved_MoveParams
    [Header("Location to move to")]
    [SerializeField] private Transform mp2;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EventTrigger"))
        {
            Destroy(other.gameObject);
            Debug.Log("Enter trigger area");
            GameManager.Instance._xrKnob.value = STOP;
        }
    }

    //TODO: Move this to TriggerInfo
    public void TypeTrigger(string type)
    {
        if (type == "Bats")
        {
            Debug.Log("release the bats");
            Vector3 posBat = playerCamera.transform.position + batsSpawnOffset;
            Vector3 direction = (playerCamera.transform.position - posBat).normalized;

            Instantiate(batsPrefab, posBat, Quaternion.LookRotation(direction));
        } else if (type == "Rock")
        {
            Debug.Log("watch out for your head");
            Vector3 posRock = playerCamera.transform.position + rocksSpawnOffset;
            Instantiate(rocksPrefab, posRock, Quaternion.identity);
        }
    }
    
    void FixedUpdate()
    {
        MoveLift();
    }

    
}
