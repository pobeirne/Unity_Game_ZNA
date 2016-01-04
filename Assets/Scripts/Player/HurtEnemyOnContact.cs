using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour
{

    private enum Damage
    {
        Skeleton = 5,
        Zombie = 5
    };

    private int damage;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        var player = transform.parent.gameObject;
        switch (other.transform.tag)
        {
            case "Skeleton":
                damage = (int)Damage.Skeleton;
                ScoreManager.TakePoints(damage * 100);
                other.GetComponent<EnemyHealthManager>().giveDamage(damage);
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x, 10f);
                break;
            case "Zombie":
                damage = (int)Damage.Zombie;
                ScoreManager.TakePoints(damage * 100);
                other.GetComponent<EnemyHealthManager>().giveDamage(damage);
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x, 5f);
                break;
            default:
                break;
        }
    }
}
