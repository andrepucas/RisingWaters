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

    // Animator variables - hashIDs
    private int groundedHash = Animator.StringToHash("Grounded");
    private int jumpHash     = Animator.StringToHash("Jump");
    private int crouchHash   = Animator.StringToHash("Crouch");
    private int runHash      = Animator.StringToHash("Run");
    private int hurtHash     = Animator.StringToHash("Hurt");

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
        PauseMenu();
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
                FindObjectOfType<AudioManager>().Play("Jump");
                return;
            }
        }

        // Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool(crouchHash, true);
        }

        // Leaving crouched state
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)
        || anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerHurt"))
        {
            anim.SetBool(crouchHash, false);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player hits an obstacle
        if (collision.CompareTag("Obstacle"))
        {
            anim.SetTrigger(hurtHash);
            FindObjectOfType<AudioManager>().Play("Hit");
        }
    }

    // Waits 2 seconds after death and returns to menu
    public IEnumerator PlayerDeath()
    {
        gameObject.SetActive(false);
        
        yield return new WaitForSeconds(3f);
        Debug.Log("Time waited.");

        SceneManager.LoadScene("GameOver");
    }

    public void PauseMenu()
    {
        if(Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("PauseMenu");
        }
    }

}