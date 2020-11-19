using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : Character
{
    public float speed;
    public float distanceToCollider;
    public LayerMask collisionLayer;

    private float horizontalInput;

    protected override void Initializtion()
    {
        base.Initializtion();
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        else
        {
            horizontalInput = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);
        if(horizontalInput != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        SpeedModifier();
    }

    private void SpeedModifier()
    {
        if((rb.velocity.x > 0 && CollisionCheck(new Vector3(col.bounds.center.x, col.bounds.center.y, col.bounds.max.z + 1), Vector3.forward, distanceToCollider, collisionLayer)) && !character.isGrounded)
        {
            rb.velocity = new Vector2(.01f, rb.velocity.y);
        }
    }
}
