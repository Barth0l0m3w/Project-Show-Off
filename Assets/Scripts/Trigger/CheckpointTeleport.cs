using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTeleport : MonoBehaviour
{
    [SerializeField] private Transform tpPoint;
    private Transform loader;

    private void Start()
    {
        loader = tpPoint.GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            loader.gameObject.SetActive(true);
            GameEvents.current.CheckpointTeleported();
            GameManager.Instance.platform.gameObject.transform.position = tpPoint.position;
        }
    }
}
