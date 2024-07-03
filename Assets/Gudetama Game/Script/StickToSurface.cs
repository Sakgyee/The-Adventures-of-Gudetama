using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToSurface : MonoBehaviour
{
    private bool isSticking = false;
    private Transform stickingObject;

    private void OnParticleTrigger(GameObject other)
    {
        {
            if (!isSticking)
            {
                // Check if the collided object is the one you want particles to stick to
                if (other.CompareTag("StickySurface"))
                {
                    isSticking = true;
                    stickingObject = other.transform;

                    // Disable the Particle System's movement and emission
                    var particleSystem = GetComponent<ParticleSystem>();
                    var mainModule = particleSystem.main;
                    mainModule.simulationSpeed = 0f; // Stop movement
                    mainModule.maxParticles = 0;     // Stop emission

                    // Attach the Particle System to the sticky object
                    transform.parent = stickingObject;
                }
            }
        }
    }

    private void DetachFromSurface()
    {
        if (isSticking)
        {
            isSticking = false;

            // Enable the Particle System's movement and emission
            var particleSystem = GetComponent<ParticleSystem>();
            var mainModule = particleSystem.main;
            mainModule.simulationSpeed = 1f; // Resume movement
            mainModule.maxParticles = 1000;  // Resume emission

            // Detach the Particle System from the sticky object
            transform.parent = null;
            stickingObject = null;
        }
    }

    // You may call this method externally when you want the particle to detach (e.g., through another script)
    public void DetachFromSurfaceExternally()
    {
        DetachFromSurface();
    }

}
