using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    
    public string enemyTag = "Enemy";

    
    public AudioClip destructionSound;

    
    private AudioSource audioSource;

    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        
        audioSource.clip = destructionSound;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag(enemyTag))
        {
            
            PlayDestructionSound();

            
            Destroy(gameObject);
        }
    }

    
    private void PlayDestructionSound()
    {
        if (audioSource != null && destructionSound != null)
        {
            audioSource.PlayOneShot(destructionSound);
        }
    }
}


