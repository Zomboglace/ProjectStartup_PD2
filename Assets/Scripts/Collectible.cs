using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 100;
    private ScoreManager scoreManager;

    
    public AudioClip collectionSound;

    
    private AudioSource audioSource;

    void Start()
    {
        
        scoreManager = FindObjectOfType<ScoreManager>();

        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        
        audioSource.clip = collectionSound;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            PlayCollectionSound();

            
            scoreManager.IncreaseScore(scoreValue);

            
            Destroy(gameObject);
        }
    }

    
    private void PlayCollectionSound()
    {
        if (audioSource != null && collectionSound != null)
        {
            audioSource.PlayOneShot(collectionSound);
        }
    }
}


