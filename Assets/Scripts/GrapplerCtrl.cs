using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplerCtrl : MonoBehaviour
{
    [SerializeField]
    private int aggroRange = 40;
    [SerializeField]
    private float maxSpeed = 25;
    private Transform target;
    private float distance;
    private Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        distance = Vector3.Distance(transform.position, target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            if(distance < aggroRange)
            {
                Vector3 velocity = rb.velocity;
                velocity.x = -maxSpeed;
                rb.velocity = velocity;
            }
            distance = Vector3.Distance(transform.position, target.position);
            Debug.Log(transform.position.x + " : " + target.position.x);
            Debug.Log("distance:" + distance);
        }
    }
}
