using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    public float speed = 1.0f;
    public float jumpHeight = 5.0f;
    private bool facingRight = true;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private LayerMask Ground;


    void Update()
    {
        //horizontal ranges between -1 and 1 based on whether the user is pressing left or right
        horizontal = Input.GetAxisRaw("Horizontal");

        //if the user presses the jump button and the player is on the ground:
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //player velocity stays the same on the x axis but the jumpHeight variable is added on the y axis
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        

        //if the user is not pressing the jump button and the upwards velocity is greater than 0:
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            //player's y velocity is halved each frame, slowing the player down
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //calls the function "Flip"
        Flip();
    }

    private void FixedUpdate()
    {
        //every frame the player velocity is the horizontal input multiplied by the speed on the x axis
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        //returns true if the box collider casted downwards comes in contact with a game object labelled "Ground"
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, Ground);
    }

    private void Flip()
    {
        //if the facing right variable is true and the player is moving left or vice versa:
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            //the x scale of the player is multiplied by -1 (it is flipped)
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
    