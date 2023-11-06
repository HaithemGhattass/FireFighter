using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPress : MonoBehaviour
{
    private Button button; // Reference to the Button component

    private void Start()
    {
        button = GetComponent<Button>(); // Get the Button component attached to this GameObject
        if (button != null)
        {
            button.onClick.AddListener(LogButtonPress); // Add a listener for the button's click event
        }
    }

    private void LogButtonPress()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>(); // Get the ScoreManager reference.
       
            scoreManager.AddToScore(100); // Adjust the pointsToAdd as needed.
        
    }
}
