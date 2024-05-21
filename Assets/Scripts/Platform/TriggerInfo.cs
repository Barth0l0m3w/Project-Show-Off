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

    [Header("Position Stops")] 
    [SerializeField] private int CoordinateBats;
    [SerializeField] private int CoordinateRock;
    //private int CoordinateStop; //more when neccecery

    [Header("Object Spawn Offset")] [SerializeField]
    private Transform batsOffset;

    [SerializeField] private Transform rockOffset;
    
    private bool BatsStop;
    private bool RocksStop;

    private void Update()
    {
        if (GameManager.Instance.face.transform.position.y <= CoordinateBats)
        {
            ReleaseTheBat();
        }

        if (GameManager.Instance.face.transform.position.y <= CoordinateRock)
        {
            ReleaseTheRocks();
        }
    }

    private void ReleaseTheBat()
    {
        if (!BatsStop)
        {
            BatsStop = true;
            Debug.Log("release the bats");
            Vector3 posBat = batsOffset.position;
            Vector3 direction = (GameManager.Instance.face.transform.position - posBat).normalized;

            Instantiate(bats, posBat, Quaternion.LookRotation(direction));
        }
    }

    private void ReleaseTheRocks()
    {
        if (!RocksStop)
        {
            RocksStop = true;
            Debug.Log("watch out for your head");
            Vector3 posRock = GameManager.Instance.face.transform.position + rockOffset.position;
            Instantiate(rock, posRock, Quaternion.identity);
        }
    }
}