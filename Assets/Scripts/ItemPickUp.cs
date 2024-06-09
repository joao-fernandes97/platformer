using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioKey;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            audioSource.clip = audioKey;
            audioSource.Play();
            FindObjectOfType<GameManager>().IncreaseKeyCounter();
            DestroyKeyCR();
        }
    }

    public void DestroyKeyCR()
    {
        StartCoroutine(DestroyKey());
    }

    private IEnumerator DestroyKey()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
