using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;


public class TriggerInfo : MonoBehaviour
{
    public MovingCube _platform;
    
    [Header("object Reference")]
    [SerializeField] private GameObject bats;
    [SerializeField] private GameObject rock;
    
    
    [Header("Object Spawn Offset")]
    [SerializeField] private Transform batsOffset;
    [SerializeField] private Transform rockOffset;
    
    public enum TriggerType
    {
        BATS,
        ROCK
    }

    [SerializeField] private TriggerType triggerType;

    //TODO: Swap out OnTriggerEnter to avoid relying on RigidBody. Maybe use raw distance check
    //OnTriggerEnter's dependant on colliders and having Rigidbodies, but we don't use that for movement or physics
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            if (triggerType == TriggerType.BATS)
            {
                Debug.Log("release the bats");
                Vector3 posBat = batsOffset.position;
                Vector3 direction = (GameManager.Instance.face.transform.position - posBat).normalized;

                Instantiate(bats, posBat, Quaternion.LookRotation(direction));
            }

            if (triggerType == TriggerType.ROCK)
            {
                Debug.Log("watch out for your head");
                Vector3 posRock = GameManager.Instance.face.transform.position + rockOffset.position;
                Instantiate(rock, posRock, Quaternion.identity);
            }
        }

        Destroy(this);
    }
}