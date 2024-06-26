using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TogEnvironment : MonoBehaviour
{
    [SerializeField]
    private CompositeCollider2D tilemapCollider;
    [SerializeField]
    private TilemapRenderer tilemapRenderer;
    public bool IsInsideGeometry { get; private set; } = false;
    public bool IsActive => gameObject.GetComponent<TilemapRenderer>().enabled;
    
    public void ToggleEnvironment()
    {
            tilemapCollider.isTrigger = !tilemapCollider.isTrigger;
            tilemapRenderer.enabled = !tilemapRenderer.enabled;  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Collision"))
        {
            IsInsideGeometry=true;
            Debug.Log("player entered geometry");
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Collision"))
        {
            IsInsideGeometry=false;
            Debug.Log("player exited geometry");
        }
    }


}
