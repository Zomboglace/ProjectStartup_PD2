using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int scoreValue = 100;
    public AudioClip pickupSound;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayPickupSound();
            AddScore();
            Destroy(gameObject);
        }
    }

    private void PlayPickupSound()
    {
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
        else
        {
            Debug.LogWarning("No audio clip assigned for Pickup sound.");
        }
    }

    private void AddScore()
    {
        if (scoreManager != null)
        {
            scoreManager.IncreaseScore(scoreValue);
        }
        else
        {
            Debug.LogWarning("ScoreManager not found. Make sure it exists in the scene.");
        }
    }
}



