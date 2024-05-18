using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float maxSpeed = 50;

    //private SpriteRenderer sr;
    private Rigidbody2D     rb;
    private Animator        animator;

    private bool amISane = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        MovingPlayer(amISane);

        /*float deltaX = Input.GetAxis("Horizontal");

        Vector3 velocity = rb.velocity;
        velocity.x = deltaX * maxSpeed;
        rb.velocity = velocity;

        //Animation
        animator.SetFloat("AbsVelocityX", Mathf.Abs(velocity.x));
        if(velocity.x < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        else if(velocity.x > 0) transform.rotation = Quaternion.identity;*/
    }

    public void MovingPlayer(bool sane)
    {
        if(sane)
        {
            float deltaX = Input.GetAxis("Horizontal");

            Vector3 velocity = rb.velocity;
            velocity.x = deltaX * maxSpeed;
            rb.velocity = velocity;
        }
        else
        {
            float deltaX = Input.GetAxis("Horizontal");

            Vector3 velocity = rb.velocity;
            velocity.x = - deltaX * maxSpeed;
            rb.velocity = velocity;
        }
    }

    public void SetSanity(bool sane)
    {
        amISane = sane;
    } 

    public void PlayerDied()
    {
        Debug.Log("Player died");
        //Destroy(this.gameObject);
    }

    public void SetSpeed()
    {
        maxSpeed = maxSpeed / 2;
    } 

}
