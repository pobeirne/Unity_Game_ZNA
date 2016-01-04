using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealth;
    public GameObject deathEffect;
    public int pointsOnDeath;

    public AudioClip enemyHurt1;
    public AudioClip enemyHurt2;
    public AudioClip enemyDeath1;
    public AudioClip enemyDeath2;

    // Update is called once per frame
    void Update () {

        if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.AddPoints(pointsOnDeath);
            SoundManager.instance.RandomizeSfx(enemyDeath1, enemyDeath2);
            Destroy(gameObject);
        }	
	}

    public void giveDamage(int damageToGive)
    {
        SoundManager.instance.RandomizeSfx(enemyHurt1, enemyHurt2);
        enemyHealth -= damageToGive;
        //GetComponent<AudioSource>().Play();
    }
}
