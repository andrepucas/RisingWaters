using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private SpriteRenderer renderer;

    // Determinates the max speed of the Player
    public float moveSpeed;

    // Variables to make the player go faster
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;

    public float speedDecrease;


    // Determinates the force of your jump in the Y axis
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

        speedMilestoneCount = speedIncreaseMilestone;
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
        
        // THIS CODE WILL BE REMOVED
        // "Slide"
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Rotate(0.0f, 0.0f, -70f);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.Rotate(0.0f, 0.0f, 70f);
        }

        // Increases movement mpeed
        if (transform.position.x > speedMilestoneCount)
        {
            // Increases the count speed
            speedMilestoneCount += speedIncreaseMilestone;

            // This makes the Milestones larger as the player moves faster
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            // Increases the moveSpeed variable
            moveSpeed = moveSpeed * speedMultiplier;
        }
    }
}
