using UnityEngine;

public class MainMenuScreen : GMBase {
      

    public void StartGame()
    {
        GM.StartGame(1);        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
