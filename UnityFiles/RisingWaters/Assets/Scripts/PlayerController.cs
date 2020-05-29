using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private SpriteRenderer renderer;
    

    // Speed Variables

    public float moveSpeed;
    public float speedInitial;
    public float speedTerminal;
    public float speedMultiplier;


    // Determines the force of your jump in the Y axis
    public float jumpForce;

    // Variables to check if the player is grounded to prevent multiple jumpings
    public LayerMask whatIsGround;
    public bool isGrounded;

    // Health Variable
    public int health = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerMovement();

        // Player dies
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
    public void PlayerMovement()
    {
        isGrounded = Physics2D.IsTouchingLayers(collider, whatIsGround);

        // Jump movement
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Jump movement inputs
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        // "Slide"
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Rotate(0.0f, 0.0f, -70f);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.Rotate(0.0f, 0.0f, 70f);
        }

        // Increases movement speed
        if (moveSpeed < speedTerminal)
        {
            // Increases the moveSpeed variable
            moveSpeed = moveSpeed * speedMultiplier;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            // Player takes damage
            moveSpeed = speedInitial;
            Debug.Log("Slowed Down.");
        }
    }
}
