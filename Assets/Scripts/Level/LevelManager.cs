using UnityEngine;

public class LevelManager : GMBase
{
    public int levelToLoad;

    void OnTriggerEnter2D(Collider2D other)
    {           
        if (other.transform.tag == "Player")
        {
            GM.UpdatePlayerLevel(levelToLoad);
            GM.StartGame(levelToLoad);
        }
    }
}
