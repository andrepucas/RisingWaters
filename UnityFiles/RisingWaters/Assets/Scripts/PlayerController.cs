using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D   rb;
    private BoxCollider2D hitbox;

    // Speed Variables
    [SerializeField] private float speedMultiplier = 1.0003f;
                     public  float moveSpeed;
                     public  float speedInitial;
                     public  float speedTerminal;

    // Determines the force of your jump in the Y axis
    [SerializeField] private float jumpForce = 170;

    // Variables to check if the player is grounded to prevent multiple jumps
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool      isGrounded;

    // Health Variables
    [SerializeField]  private int initialHealth = 2;
    [HideInInspector] public  int health;

    // Start is called before the first frame update
    void Start()
    {
        rb     = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
        health = initialHealth;
        whatIsGround = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();

        // Player dies
        if (health == 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void PlayerMovement()
    {
        isGrounded = Physics2D.IsTouchingLayers(hitbox, whatIsGround);

        // Jump movement
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Jump movement inputs
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Jump limitations
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        // Crouch
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
            
            // Terminal speed reached
            if (moveSpeed >= speedTerminal)
            {
                moveSpeed = speedTerminal;
                health    = initialHealth;
            }
        }
    }
}