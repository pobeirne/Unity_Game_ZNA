using UnityEngine;

public class KunaiController : MonoBehaviour
{
    //Movement
    public float moveSpeed;
    private Rigidbody2D rb2D;

    //
    public PlayerController player;

    //
    private int damageToGive;

    //
    public GameObject minusText;
    public GameObject impactEffect;
    public GameObject enemyDeathEffect;

    public AudioClip impact1;
    public AudioClip impact2;



    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        //Flip
        if (player.transform.localScale.x < 0)
        {
            moveSpeed = -moveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector2(moveSpeed, rb2D.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Skeleton")
        {
            damageToGive = 1;
            Instantiate(minusText, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
        }
        if (other.transform.tag == "Zombie")
        {
            damageToGive = 1;
            Instantiate(minusText, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
        }

        //Default
        SoundManager.instance.RandomizeSfx(impact1, impact2);
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
