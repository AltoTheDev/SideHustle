using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float drag;

    public Rigidbody2D body;

    public BoxCollider2D groundCheck;

    public LayerMask groundMask;


    public bool grounded;

    void Start()
    {
        
    }

    
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");


        if (Mathf.Abs(xInput) > 0)
        {
            body.velocity = new Vector2(xInput * speed, body.velocity.y);
        }

        if (Mathf.Abs(yInput) > 0)
        {
            body.velocity = new Vector2(body.velocity.x, yInput * speed);
        }


        void FixedUpdate()
        {
            if (grounded)
            {
                body.velocity *= 0.9f;
            }
            
        }

        void CheckGround()
        {
            grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        }


        //Vector2 direction = new Vector2(xInput, yInput).normalized;
        //body.velocity = direction * speed;
    }
}
