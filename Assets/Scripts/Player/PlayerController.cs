using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Player 
    public float moveSpeed;
    public float moveVelocity;
    public float jumpForce;
    private bool hasJumped;
    private Rigidbody2D rb2D;

    private bool actionTaken;

    //Ground
    public bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;


    //Animation
    private Animator animator;

    //Shooting
    public Transform firePoint;
    public GameObject ninjaKunai;
    public float shotDelay;
    private float shotDelayCounter;

    //Knockback
    public float knockback;
    public float knockbackLenght;
    public float knockbackCount;
    public bool knockbackRight;


    //Ladder
    public bool isOnLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    //Audio clip
    public AudioClip playerJump1;
    public AudioClip playerJump2;

    public AudioClip playerShoot1;
    public AudioClip playerShoot2;

    public AudioClip playerHurt1;
    public AudioClip playerHurt2;


    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gravityStore = rb2D.gravityScale;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded) { hasJumped = false; }
        actionTaken = false;

        //Move Left Right
        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

        //Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2D.velocity = new Vector2(moveVelocity, jumpForce);
            grounded = false;
            SoundManager.instance.RandomizeSfx(playerJump1, playerJump2);
        }

        if (Input.GetButtonDown("Jump") && !hasJumped && !grounded)
        {
            rb2D.velocity = new Vector2(moveVelocity, jumpForce);
            hasJumped = true;
            grounded = false;
            SoundManager.instance.RandomizeSfx(playerJump1, playerJump2);
        }

        //Shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ninjaKunai, firePoint.position, firePoint.rotation);
            shotDelayCounter = shotDelay;
            actionTaken = true;
            SoundManager.instance.RandomizeSfx(playerShoot1, playerShoot2);
        }

        if (Input.GetButton("Fire1"))
        {
            shotDelayCounter -= Time.fixedDeltaTime;

            if (shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Instantiate(ninjaKunai, firePoint.position, firePoint.rotation);
            }
            actionTaken = true;
            SoundManager.instance.RandomizeSfx(playerShoot1, playerShoot2);
        }

        //climb 
        if (isOnLadder)
        {
            rb2D.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            rb2D.velocity = new Vector2(rb2D.velocity.x, climbVelocity);
        }
        else if (!isOnLadder)
        {
            rb2D.gravityScale = gravityStore;
        }


        if (knockbackCount <= 0)
        {
            rb2D.velocity = new Vector2(moveVelocity, rb2D.velocity.y);
        }
        else
        {
            if (knockbackRight)
            {
                rb2D.velocity = new Vector2(-knockback, knockback);               
            }
            else if (!knockbackRight)
            {
                rb2D.velocity = new Vector2(knockback, knockback);
            }
            SoundManager.instance.RandomizeSfx(playerHurt1, playerHurt2);
            knockbackCount -= Time.deltaTime;
        }


        //Flip
        if (rb2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else if (rb2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }

        //Animations
        animator.SetBool("Grounded", grounded);
        animator.SetBool("Action", actionTaken);
        animator.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
    }
}
