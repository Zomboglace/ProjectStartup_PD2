using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // Reference to a Text component to display the score
    private int score = 0;  // Variable to store the current score

    void Start()
    {
        // Initialize the score display
        UpdateScoreText();
    }

    // Call this method to increase the score by a specified amount
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // Update the score text on the UI
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
