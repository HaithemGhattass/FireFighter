using UnityEngine;

public class FireParticleSystemController : MonoBehaviour
{
    private ParticleSystem fireParticleSystem;

    private void Start()
    {
        fireParticleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("WaterParticle")) // Adjust the tag as needed
        {
            var emission = fireParticleSystem.emission;
            emission.enabled = false; // Disable the emission, effectively "killing" the fire particles.

            // Optionally, you can also destroy the GameObject after a delay to remove it from the scene completely.
            Destroy(gameObject, 2.0f); // Adjust the delay as needed.
        }
    }
}
