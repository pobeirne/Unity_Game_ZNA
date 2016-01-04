using UnityEngine.UI;

public class LifeManager : GMStaticBase
{
    public static int lives;
    private Text text;

    void Start()
    {
        base.Init();
        text = GetComponent<Text>();
        if (GM._player.lives != 0)
        {
            lives = GM._player.lives;
        }
        else
        {
            ResetLives();
        }
       
    }
    void Update()
    {
        if (lives >= 0)
        {
            text.text = "" + lives;
        }
    }
    public static void AddLiveToPlayer()
    {
        lives++;
    }
    public static void TakeLiveFromPlayer()
    {
        if (lives > 0)
        {
            lives--;
            GM.UpdatePlayerLives(lives);
            GM.OnDeathKillPlayer();

            if (lives > 0)
            {
                HealthManager.ResetHealth();
                GM.RespawnPlayer();
            }
            if (lives == 0)
            {
                GM.OnDeathKillPlayer();
                GM.GameOver();
            }
        }

    }
    public void ResetLives()
    {
        lives = 3;
        GM.UpdatePlayerLives(lives);
    }
}
