using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    //public float speedOffset = 1;
    [HideInInspector]public float currentState;
    [SerializeField]private float stoppingDeceleration;
    [SerializeField]private float cruisingTopSpeed;
    [SerializeField]private float cruisingAcceleration;
    [SerializeField]private float freefallTopSpeed;
    [SerializeField]private float freefallAcceleration;
    private const float STOP = 0;
    private const float CRUISE = 0.5f;
    private const float FREEFALL = 1;

    private float currentSpeed = 0;
    

    [SerializeField] private Transform mp2;


    private Vector3 p2;
    private Vector3 currentTarget;
    
    // Start is called before the first frame update
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
    
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveLift();
        //float step = speed * speedOffset * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
    }

    
}
