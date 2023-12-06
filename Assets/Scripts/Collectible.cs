using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 100;
    private ScoreManager scoreManager;

    void Start()
    {
        // Find the ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increase the score when the player collects the item
            scoreManager.IncreaseScore(scoreValue);

            // Optionally, you can destroy the collected item
            Destroy(gameObject);
        }
    }
}

