using UnityEngine;

public class CrosshairManager : MonoBehaviour
{
    public GameObject crosshair; // Reference to the crosshair GameObject

    private ScoreManager scoreManager; // Reference to the ScoreManager script

    private void Start()
    {
        crosshair.SetActive(false); // Start with the crosshair hidden
        scoreManager = FindObjectOfType<ScoreManager>(); // Find the ScoreManager script
    }

    private void Update()
    {
        if (scoreManager.GetScore() > 0)
        {
            crosshair.SetActive(true); // Show the crosshair when score is greater than 0
        }
        else
        {
            crosshair.SetActive(false); // Hide the crosshair when score is 0 or less
        }
    }
}
