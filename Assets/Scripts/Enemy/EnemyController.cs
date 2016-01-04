using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Enemy
    private Rigidbody2D rb2D;
    public float moveSpeed;
    public bool moveRight;

    //Wall Check
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool isHittingWall;

    //Edge    
    public Transform edgeCheck;
    private bool isEdge;


    //Animation
    private Animator animator;
    private bool hasSpawned;
    public bool takeAction;


    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        EnemySpawnAnimation();
    }

    void FixedUpdate()
    {
        isHittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        isEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSpawned)
        {
            //Animations       
            animator.SetBool("Spawned", hasSpawned);

            if (isHittingWall || !isEdge)
            {
                moveRight = !moveRight;
            }

            if (moveRight)
            {
                transform.localScale = new Vector3(-0.35f, 0.35f, 0.35f);
                rb2D.velocity = new Vector2(moveSpeed, rb2D.velocity.y);
            }
            if (!moveRight)
            {
                transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                rb2D.velocity = new Vector2(-moveSpeed, rb2D.velocity.y);
            }

            if (takeAction)
            {
                animator.SetBool("TakeAction", takeAction);
                EnemyStopAnimation();
            }
        }


    }

    public void EnemySpawnAnimation()
    {
        StartCoroutine("SpawnEnemyAnimationCR");
    }
    public IEnumerator SpawnEnemyAnimationCR()
    {
        yield return new WaitForSeconds(1);
        hasSpawned = true;
    }

    public void EnemyStopAnimation()
    {
        StartCoroutine("StopEnemyAnimationCR");
    }
    public IEnumerator StopEnemyAnimationCR()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("TakeAction", false);
        takeAction = false;
    }
}
