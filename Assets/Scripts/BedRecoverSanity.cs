using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRecoverSanity : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioBed;
    private bool playerInTrigger;

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.S))
        {
            audioSource.clip = audioBed;
            audioSource.Play();
            FindObjectOfType<Sanity>().ResetSanity();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
}
