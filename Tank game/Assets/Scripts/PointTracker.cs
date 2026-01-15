using UnityEngine;

public class PointTracker : MonoBehaviour
{
    public int combo = 1;
    public int points = 0;
    public int bestScore = 0;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void AddPoints()
    {
        points += combo * 10;
    }

    public void CheckAndSaveHighScore()
    {
        if (points > bestScore)
        {
            bestScore = points;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }
}