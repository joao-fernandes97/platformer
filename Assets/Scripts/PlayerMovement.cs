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

    //private RespawnPlayer respawnPlayer;

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
        Falling();
    }

    public void Falling()
    {
        if (transform.position.y < - 70)
        {
            transform.position = new Vector3(250,-15,0);
        }
    }

    public void MovingPlayer(bool sane)
    {
        if(sane)
        {
            float deltaX = Input.GetAxis("Horizontal");

            Vector3 velocity = rb.velocity;
            velocity.x = deltaX * maxSpeed;
            rb.velocity = velocity;

            AnimPlayer(rb.velocity);
        }
        else
        {
            float deltaX = Input.GetAxis("Horizontal");

            Vector3 velocity = rb.velocity;
            velocity.x = - deltaX * maxSpeed;
            rb.velocity = velocity;

            AnimPlayer(rb.velocity);
        }
    }

    public void AnimPlayer(Vector3 velocity)
    {
        //warning on unity about the animator?
        animator.SetFloat("AbsVelocityX", Mathf.Abs(velocity.x));
        if(velocity.x < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        else if(velocity.x > 0) transform.rotation = Quaternion.identity;
    }

    public void SetSanity(bool sane)
    {
        amISane = sane;
    } 

    public void PlayerDied()
    {
        Destroy(this.gameObject);
        //Debug.Log("Player died.");
    }

    public void SetSpeed()
    {
        maxSpeed = maxSpeed / 2;
    } 

    public void ResetMVSpeed()
    {
        maxSpeed = 50;
    }

}
