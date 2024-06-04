using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBedRoom : MonoBehaviour
{
    private bool playerInTrigger;

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<GameManager>().FirstLevelCR();
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
