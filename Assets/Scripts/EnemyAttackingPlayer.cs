using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject sanity;

    [SerializeField]
    private float sanityAmount;

    [SerializeField]
    private GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            Sanity enemyAttack = sanity.GetComponent<Sanity>(); 
            enemyAttack.CrawlerGrab(sanityAmount);
        }
    }
}
