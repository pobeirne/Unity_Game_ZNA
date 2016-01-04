using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : GMStaticBase
{

    public static int health;
    private Text text;

    public AudioClip playerHurt1;
    public AudioClip playerHurt2;  

    void Start()
    {
        base.Init();
        text = GetComponent<Text>();
        if (GM._player.health != 0)
        {
            health = GM._player.health;
        }
        else
        {
            ResetHealth();
        }
    }
   
    void Update()
    {     
        if (health >= 0)
        {
            text.text = "" + health;
        }
    }

    public static void HurtPlayer(int damageToGive)
    {
        if (health > 0)
        {
            health -= damageToGive;
            GM.UpdatePlayerHealth(health);            
        }
        if (health <= 0)
        {
            LifeManager.TakeLiveFromPlayer();
        }
    }   

    public static void ResetHealth()
    {
        health = 10;
        GM.UpdatePlayerHealth(health);
    }
}
