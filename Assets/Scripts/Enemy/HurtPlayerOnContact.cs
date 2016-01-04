using System.Collections;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{

    private enum Damage
    {
        Acid = 10,
        Spike = 1,
        Skeleton = 1,
        Zombie = 1
    };

    private int damage;

    public GameObject minusText;
    private bool takeAction;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {


            var player = other.GetComponent<PlayerController>();
            var me = GetComponent<EnemyController>();

            switch (transform.tag)
            {
                case "Acid":
                    damage = (int)Damage.Acid;
                    ScoreManager.TakePoints(damage * 100);
                    break;
                case "Spike":
                    damage = (int)Damage.Spike;
                    ScoreManager.TakePoints(damage * 100);
                    Instantiate(minusText, new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z), Quaternion.identity);
                    break;
                case "Skeleton":
                    damage = (int)Damage.Skeleton;

                    me.takeAction = true;

                    player.knockbackCount = player.knockbackLenght;
                    if (other.transform.position.x < transform.position.x)
                    {
                        player.knockbackRight = true;
                    }
                    else
                    {
                        player.knockbackRight = false;
                    }

                    ScoreManager.TakePoints(damage * 100);
                    Instantiate(minusText, new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z), Quaternion.identity);                    
                    break;
                case "Zombie":
                    damage = (int)Damage.Zombie;
                    me.takeAction = true;

                    player.knockbackCount = player.knockbackLenght;
                    if (other.transform.position.x < transform.position.x)
                    {
                        player.knockbackRight = true;
                    }
                    else
                    {
                        player.knockbackRight = false;
                    }
                                        
                    ScoreManager.TakePoints(damage * 100);
                    Instantiate(minusText, new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z), Quaternion.identity);                    
                    break;
                default:
                    break;
            }

            HealthManager.HurtPlayer(damage);
        }
    }   
}
