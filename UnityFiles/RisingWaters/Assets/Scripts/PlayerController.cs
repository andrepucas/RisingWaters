using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider;

    // Determinates the max speed of the Player
    public float moveSpeed;

    // Determinates the force of your jump in the Y axis
    public float jumpForce;

    // Variables to check if the player is grounded to prevent multiple jumpings
    public LayerMask whatIsGround;
    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }

    //player is touching the ground
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    //player is in the air
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag != "Ground")
        {
            isGrounded = false;
        }
    }
}
