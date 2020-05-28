using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider;

    // Determinates the max speed of the Player
    public float moveSpeed;

    // Variables to make the player go faster
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;

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

        speedMilestoneCount = speedIncreaseMilestone;
    }

    private void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(collider, whatIsGround);

        // Jump movement
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Jump movement inputs
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }          
        }

        // Increases movement mpeed
        if(transform.position.x > speedMilestoneCount)
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
