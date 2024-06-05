using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrapplerCtrl : MonoBehaviour
{
    [SerializeField]
    private int             aggroRange = 40;
    [SerializeField]
    private float           maxSpeed = 25;
    [SerializeField]
    private TilemapRenderer activeLayer;
    [SerializeField]
    private Collider2D      grabDetection;

    private Transform       target;
    private float           distance;
    private Rigidbody2D     rb;
    private SpriteRenderer  sr;
    private bool            isActive = true;
    private bool            isChasing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        distance = Vector3.Distance(transform.position, target.position);

        InvokeRepeating(nameof(AlternateState), 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        grabDetection.enabled = activeLayer.enabled;
        sr.enabled = grabDetection.enabled;
        
        if(target != null && activeLayer.enabled && isActive)
        {
            //chase player
            Chase();
        }
    }

    private void Chase()
    {
        if(distance < aggroRange && distance > 10)
        {
            isChasing=true;
            Vector3 velocity = rb.velocity;
            if(target.position.x < transform.position.x)
            {                    
                velocity.x = -maxSpeed;
                transform.rotation = Quaternion.identity;
            }
            else
            {
                velocity.x = maxSpeed;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            rb.velocity = velocity;
        }else
            isChasing = false;
        distance = Vector3.Distance(transform.position, target.position);
        //Debug.Log(transform.position.x + " : " + target.position.x);
        Debug.Log("distance:" + distance);
    }

    private void AlternateState()
    {
        if(!isChasing)isActive = !isActive;
    }
}
