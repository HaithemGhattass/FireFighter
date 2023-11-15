using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waterCollision : MonoBehaviour
{
    public FireScore fireScore;
    public List<ParticleSystem> particleSystems; // List to hold Particle Systems
    public TextMeshProUGUI FireScoreText;

    private bool allSystemsStopped = false;

    void Start()
    {
        // Initialize the list of Particle Systems
        particleSystems = new List<ParticleSystem>();
    }

    void Update()
    {
        // Check if all Particle Systems have stopped
        bool allStopped = true;

        foreach (ParticleSystem ps in particleSystems)
        {
            if (ps.isPlaying)
            {
                allStopped = false;
                break;
            }
        }

        if (allStopped && !allSystemsStopped)
        {
            allSystemsStopped = true;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("SS"))
        {
            ParticleSystem ps = other.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Stop();
               

                // Add the Particle System to the list
                if (!particleSystems.Contains(ps))
                {
                    particleSystems.Add(ps);
                    FireScoreText.text = "all : " + particleSystems.Count;
                    fireScore.AddFireScore(particleSystems.Count);

                }
            }
        }
    }
}
