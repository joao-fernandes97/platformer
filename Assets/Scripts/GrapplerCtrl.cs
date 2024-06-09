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
    private PlayerMovement  tMovement;
    private float           tSpeed;
    private float           distance;
    private Rigidbody2D     rb;
    private SpriteRenderer  sr;
    private Animator        animator;
    private bool            isActive = true;
    private bool            isChasing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        tMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        distance = Vector3.Distance(transform.position, target.position);

        InvokeRepeating(nameof(AlternateState), 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        grabDetection.enabled = activeLayer.enabled && isActive;
        sr.enabled = activeLayer.enabled;
        tSpeed = tMovement.CurrentSpeed;

        if(target != null && activeLayer.enabled && isActive && tSpeed>0)
        {
            //chase player
            Chase();
        }
    }

    private void Chase()
    {
        Vector3 velocity = rb.velocity;
        if(distance < aggroRange && distance > 10)
        {
            isChasing=true;
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

        animator.SetFloat("AbsVelocityX", Mathf.Abs(velocity.x));
        distance = Vector3.Distance(transform.position, target.position);
        //Debug.Log(transform.position.x + " : " + target.position.x);
        Debug.Log("distance:" + distance);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void AlternateState()
    {
        if(!isChasing)isActive = !isActive;
        animator.SetBool("isActive", isActive);
    }
}
