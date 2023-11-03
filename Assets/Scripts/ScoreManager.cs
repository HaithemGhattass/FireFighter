using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int extinguisher = 0;

    public int GetScore()
    {
        return extinguisher;
    }

    public void AddToScore(int totalextinguisher)
    {
        extinguisher += totalextinguisher;
    }
}
