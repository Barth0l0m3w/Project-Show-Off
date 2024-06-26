using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private ParticleSystem pSys;
    [SerializeField] private float rotationSpeed = 0.3f;
    private bool rotate = true;
    private XRBaseInteractable _baseInteractable;

    private void Start()
    {
        _baseInteractable = GetComponent<XRBaseInteractable>();
        pSys.Play();
    }

    private void FixedUpdate()
    {
        if(rotate)transform.Rotate(Vector3.up, rotationSpeed);
    }

    public void FlipRotationState()
    {
        bool currentRotate = rotate;
        rotate = !currentRotate;
    }
}
