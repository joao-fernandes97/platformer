using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    [SerializeField]
    private Transform objectToFollow;
    [SerializeField]
    private BoxCollider2D cameraBounds;
    [SerializeField]
    private float     speed = 0.5f;
    [SerializeField]
    private float     yOffset;

    private Vector3 minBounds;
    private Vector3 maxBounds;

    void Start()
    {
        if(cameraBounds != null)
        {
            Bounds bounds = cameraBounds.bounds;
            minBounds = bounds.min;
            maxBounds = bounds.max;
            Debug.Log(minBounds.x +" "+ maxBounds.x +" "+ minBounds.y +" "+ maxBounds.y);
        }
        else
        {
            Debug.LogWarning("Bounds collider not assigned");
        }
    }
    
    void FixedUpdate()
    {
        if (objectToFollow != null)
        {
            Vector3 targetPosition = objectToFollow.position;

            //targetPosition.z = transform.position.z;
            //targetPosition.y += yOffset;
            //attempt was made at bounding camera, it isnt working and I cant
            //figure out why
            targetPosition.z = transform.position.z;
            targetPosition.y = Mathf.Clamp(targetPosition.y+yOffset, minBounds.y, maxBounds.y);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);

            //Debug.Log("target: " + targetPosition.y+yOffset + " " + targetPosition.x);
            //Debug.Log("actual: " + Mathf.Clamp(targetPosition.y+yOffset, minBounds.y, maxBounds.y) +" " + Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x));
            Vector3 delta = targetPosition - transform.position;

            transform.position = transform.position + delta * speed;
        }
    }
}
