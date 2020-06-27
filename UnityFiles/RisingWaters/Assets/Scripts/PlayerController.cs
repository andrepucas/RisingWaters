using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D   rb;
    private BoxCollider2D hitbox;
    private Animator anim;

    // Speed Variables
    [SerializeField]  private float speedMultiplier = 50.02f;
                      public  float moveSpeed;
                      public  float speedInitial;
                      public  float speedTerminal;

    // Determines the force of your jump in the Y axis
    [SerializeField]  private float jumpForce = 170;

    // Variables to check if the player is grounded to prevent multiple jumps
    [SerializeField]  private LayerMask whatIsGround;
    [SerializeField]  private bool      isGrounded;

    // Health Variables
    [SerializeField]  private int initialHealth = 2;
    [HideInInspector] public  int health;

    // Animator variables
    private int groundedHash = Animator.StringToHash("isGrounded");
    private int jumpHash = Animator.StringToHash("Jump");

    // Start is called before the first frame update
    void Start()
    {
        rb     = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
        anim   = GetComponent<Animator>();
        health = initialHealth;
        whatIsGround = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void FixedUpdate()
    {
        PlayerSpeed();
    }

    public void PlayerMovement()
    {
        isGrounded = Physics2D.IsTouchingLayers(hitbox, whatIsGround);
        anim.SetBool(groundedHash, isGrounded);

        // Jump movement
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Jump movement inputs
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Jump limitations
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetTrigger(jumpHash);
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
    }

    public void PlayerSpeed()
    {
        // Increases movement speed
        if (moveSpeed < speedTerminal)
        {
            // Increases the moveSpeed variable
            moveSpeed = moveSpeed * speedMultiplier * Time.fixedDeltaTime;
            
            // Terminal speed reached
            if (moveSpeed >= speedTerminal)
            {
                moveSpeed = speedTerminal;
                health    = initialHealth;
            }
        }
    }


    // Called in Obstacle, wait 3 seconds after death and returns to menu
    public IEnumerator PlayerDeath()
    {
        gameObject.SetActive(false);
        
        yield return new WaitForSeconds(3f);
        Debug.Log("Time waited.");

        SceneManager.LoadScene("MainMenu");
    }
}