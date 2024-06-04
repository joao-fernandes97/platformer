using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Sound.Play();
            FindObjectOfType<GameManager>().IncreaseKeyCounter();
            Destroy(this.gameObject);
        }
    }
}
