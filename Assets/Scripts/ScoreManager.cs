using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  
    private int score = 0;  

    void Start()
    {
        
        UpdateScoreText();
    }

    
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
