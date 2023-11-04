using System.Collections;
using UnityEngine;

public class WaterShooter : MonoBehaviour
{
    public ScoreManager scoreManager; // Reference to the ScoreManager script
    public ParticleSystem waterParticleSystem; // Reference to the water Particle System
    public float shootingDuration = 0.5f; // Duration for shooting

    private bool isShooting = false;
    private float shootingTimer = 0f;
    void Start()
    {
        StopShooting();
    }
    void Update()
    {
        if (scoreManager.GetScore() > 0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began && !isShooting)
                {
                    StartShooting();
                }
                else if (touch.phase == TouchPhase.Ended && isShooting)
                {
                    StopShooting();
                }
            } else
            {
                StopShooting();
            }
/*
            if (isShooting)
            {
                shootingTimer += Time.deltaTime;
                if (shootingTimer >= shootingDuration)
                {
                    StopShooting();
                }
            }
            */
        }
    }

    private void StartShooting()
    {
        isShooting = true;
        shootingTimer = 0f;
        waterParticleSystem.Play(); // Start the water particle system
    }

    private void StopShooting()
    {
        isShooting = false;
        shootingTimer = 0f;
        waterParticleSystem.Stop(); // Stop the water particle system
    }
}
