using UnityEngine;

public class GameOverScreen : GMBase
{
   
    public void PlayAgain()
    {        
        GM.StartGame(1);         
    }

    public void QuitToMainMenu()
    {
        Application.LoadLevel(0);
    }
}
