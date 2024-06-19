using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAvoidance : MonoBehaviour
{
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;
    [SerializeField] private float avoidArea = 0.7f;
    [SerializeField] private float minRepelCoeff = 0.1f;
    [SerializeField] private float maxRepelCoeff = 1f;
    [SerializeField] private float updateVelocityRate = 5f;

    private ParticleSystem pSys;

    private void Start()
    {
        pSys = GetComponent<ParticleSystem>();
        var main = pSys.main;
        main.simulationSpace = ParticleSystemSimulationSpace.World;
        pSys.Play();
    }

    void AvoidHands()
    {
        var particles = new ParticleSystem.Particle[pSys.main.maxParticles];
        var currentAmount = pSys.GetParticles(particles);

        for (int i = 0; i < currentAmount; i++)
        {
            Vector3 closestHand = Vector3.Distance(leftHand.position, particles[i].position) <
                                  Vector3.Distance(rightHand.position, particles[i].position) 
                                ? leftHand.position 
                                : rightHand.position;
            
            Vector3 currentVelocity = particles[i].velocity;
            float distanceToClosestHand = Vector3.Distance(particles[i].position, closestHand);
            Vector3 direction = Vector3.ProjectOnPlane(particles[i].position - closestHand, Vector3.up).normalized;

            if (distanceToClosestHand <= avoidArea)
            {
                Debug.Log("In avoid area");
                float forceMultiplier = Mathf.Lerp(maxRepelCoeff,  minRepelCoeff, distanceToClosestHand / avoidArea);
                Vector3 avoidanceForce = direction * forceMultiplier * (avoidArea - distanceToClosestHand);
                particles[i].velocity = Vector3.Lerp(currentVelocity, currentVelocity + avoidanceForce, Time.deltaTime * updateVelocityRate);
            }
            
        }
        
        pSys.SetParticles(particles, currentAmount);
    }

    private void Update()
    {
        if(this.gameObject.activeSelf)AvoidHands();
    }
}
