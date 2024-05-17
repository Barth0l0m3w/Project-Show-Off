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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Platform")
        {
            if (triggerType == TriggerType.BATS)
            {
                Debug.Log("release the bats");
                Vector3 posBat = GameManager.Instance.face.transform.position + batsOffset.position;
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