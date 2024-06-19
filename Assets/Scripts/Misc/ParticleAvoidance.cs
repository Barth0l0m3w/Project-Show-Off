using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAvoidance : MonoBehaviour
{
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;

    private ParticleSystem pSys;

    private void Start()
    {
        pSys = GetComponent<ParticleSystem>();
    }

    void AvoidHands()
    {
        var particles = new ParticleSystem.Particle[pSys.main.maxParticles];
        var currentAmount = pSys.GetParticles(particles);

        for (int i = 0; i < currentAmount; i++)
        {
            Vector3 closestHand;
            if (Vector3.Distance(leftHand.position, particles[i].position) >
                Vector3.Distance(rightHand.position, particles[i].position)) closestHand = leftHand.position;
            else closestHand = rightHand.position;
            
            Vector3 currentVelocity = particles[i].velocity;
            float distanceToClosestHand = Vector3.Distance(particles[i].position, closestHand);
            Vector3 direction = Vector3.ProjectOnPlane(particles[i].position - closestHand, Vector3.up);
        }
        
        pSys.SetParticles(particles, currentAmount);
    }
    
}
