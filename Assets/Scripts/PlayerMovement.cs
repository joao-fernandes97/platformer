using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float maxSpeed = 100;

    private SpriteRenderer sr;

    private Rigidbody2D rb;

    private bool amISane = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        MovingPlayer(amISane);

        //if(Input.GetAxis("Horizontal") != 0)
        //{
            //sr.color = Color.green;
        //}
        //else
        //{
            //sr.color = Color.red;
        //}
        //mover com transform
        //Vector3 moveVector = new Vector3(deltaX * maxSpeed * Time.deltaTime, 0, 0);
        //transform.position = transform.position + moveVector;
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

}
