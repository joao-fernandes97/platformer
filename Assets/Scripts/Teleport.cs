using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TeleportPlayer(bool choice, float distance)
    {
        if(choice)
        {
            Vector3 currentPosition = transform.position;

            Vector3 newPosition = new Vector3(currentPosition.x + distance, currentPosition.y, currentPosition.z);

            transform.position = newPosition;
        }
        else
        {
            Vector3 currentPosition = transform.position;

            Vector3 newPosition = new Vector3(currentPosition.x - distance, currentPosition.y, currentPosition.z);

            transform.position = newPosition;
        }
    }
}
