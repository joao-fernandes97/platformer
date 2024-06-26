using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrue : MonoBehaviour
{
    [SerializeField]
    private GameObject sanity;

    [SerializeField]
    private float sanityAmount;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float distance;

    [SerializeField]
    private bool correctChoice;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            Teleport teleportScript = player.GetComponent<Teleport>();
            teleportScript.TeleportPlayer(correctChoice,distance);

            Sanity puzzle = sanity.GetComponent<Sanity>(); 
            puzzle.WrongPuzzleChoice(sanityAmount);
        }
    }
}
