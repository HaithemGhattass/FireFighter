using UnityEngine;

public class FireParticleSystemController : MonoBehaviour
{
    public ParticleSystem fireParticleSystem; // Assign the fire particle system in the Inspector.
    public ParticleSystem waterParticleSystem; // Assign the water particle system in the Inspector.

    private bool isColliding = false;

    private void Update()
    {
        // Check for collisions between fire and water particles.
        if (IsColliding())
        {
            if (!isColliding)
            {
                isColliding = true;
                DisableFireParticleSystem();
            }
        }
        else
        {
            isColliding = false;
        }
    }

    private bool IsColliding()
    {
        ParticleSystem.Particle[] fireParticles = new ParticleSystem.Particle[fireParticleSystem.main.maxParticles];
        int numFireParticles = fireParticleSystem.GetParticles(fireParticles);

        ParticleSystem.Particle[] waterParticles = new ParticleSystem.Particle[waterParticleSystem.main.maxParticles];
        int numWaterParticles = waterParticleSystem.GetParticles(waterParticles);

        for (int i = 0; i < numFireParticles; i++)
        {
            for (int j = 0; j < numWaterParticles; j++)
            {
                // You may want to adjust this threshold based on your particle system's scale and settings.
                if (Vector3.Distance(fireParticles[i].position, waterParticles[j].position) < 0.1f)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void DisableFireParticleSystem()
    {
        var emission = fireParticleSystem.emission;
        emission.enabled = false; // Disable the emission, effectively "killing" the fire particles.

        // Optionally, you can also destroy the GameObject after a delay to remove it from the scene completely.
        Destroy(gameObject, 2.0f); // Adjust the delay as needed.
    }
}
