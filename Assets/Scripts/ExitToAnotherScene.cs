using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToAnotherScene : MonoBehaviour
{
    private bool playerInTrigger;

    //TODO: Make this generic, serialize field to pass Scene Name, and one to add a required item
    
    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<GameManager>().NextSceneCR();
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
