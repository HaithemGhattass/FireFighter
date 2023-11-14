using System.Collections;
using UnityEngine;

public class TueauShoot : MonoBehaviour
{
    public ScoreManager scoreManager; // Reference to the ScoreManager script
    public ParticleSystem waterParticleSystem; // Reference to the water Particle System
    public float shootingDuration = 0.5f; // Duration for shooting
   public FireScore fireScore;

    private bool isShooting = false;
    private float shootingTimer = 0f;
    void Start()
    {
        StopShooting();
    }
    void Update()
    {
        
            if (scoreManager.GetScore() > 1)
            {
               
               if(fireScore.getFireScore() > 0) {
                     if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);

                        if (touch.phase == TouchPhase.Began && !isShooting)
                        {
                            StartShooting();
                        }
                        else if (touch.phase == TouchPhase.Ended && isShooting )
                        {
                            StopShooting();
                        }
                    } else
                    {
                        StopShooting();
                    }
                 } else {
                    StopShooting();

                    }

            }  
    }

    private void StartShooting()
    {
        isShooting = true;
        shootingTimer = 0f;
        waterParticleSystem.Play(); // Start the water particle system
        AudioManager.Instance.playSFX("FireExtinguisher");
    }

    private void StopShooting()
    {
        isShooting = false;
        shootingTimer = 0f;
        waterParticleSystem.Stop(); // Stop the water particle system
                AudioManager.Instance.stopSFX("FireExtinguisher");

    }
}
