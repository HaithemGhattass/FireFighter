using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private ScoreManager scoreManager;
    public static int scoreCount;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        
        UpdateScoreDisplay();
    }

    private void Update()
    {
         UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay()
    {
        if (scoreText != null && scoreManager != null)
        {
            scoreText.text = "Tools: " + scoreManager.GetScore().ToString();
        }
    }
}
