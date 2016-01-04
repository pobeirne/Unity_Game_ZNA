using System.Collections;
using UnityEngine;

public enum GameState
{
    NullState, Menu, Playing, Paused, GameOver
}
public delegate void OnStateChangeHandler();
public class PlayerInfo
{
    public int id;
    public int score;
    public int health;
    public int lives;
    public int level;
    public GameState gameState;
    public GameObject checkPoint;

}

public class GameManager : MonoBehaviour
{
    //
    public static GameManager instance = null;

    //
    public GameState gameState
    {
        get;
        private set;
    }
    public event OnStateChangeHandler OnStateChange;

    //
    public PlayerInfo _player = null;
    public GameObject playerAlive;
    public GameObject playerDeath;
    public GameObject spawnPartical;
    public GameObject deathPartical;

    public AudioClip playerHurt1;
    public AudioClip playerHurt2;
    public AudioClip playerDeath1;
    public AudioClip playerDeath2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        OnStateChange += HandleOnStateChange;

        InitGame();
    }


    void InitGame()
    {
        Application.LoadLevel(0);
        SetGameState(GameState.Menu);
    }
    public void HandleOnStateChange()
    {
        //Debug.Log("Handling state change to: " + gameState);
    }
    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        if (OnStateChange != null)
        {
            OnStateChange();
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            SetGameState(GameState.Menu);
            Application.LoadLevel(0);
            //Debug.Log("Name: " + Application.loadedLevelName);
        }
        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            SetGameState(GameState.Playing);
            Application.LoadLevel(1);
            //Debug.Log("Name: " + Application.loadedLevelName);
        }
    }
    public void StartGame(int level)
    {
        if (level == 0)
        {
            SetGameState(GameState.Menu);            
            _player.score = 0;
            _player.health = 0;
            _player.lives = 0;
            Application.LoadLevel(level);
        }

        if (level == 1)
        {
            _player = new PlayerInfo();
            _player.id = Random.Range(1, 1000);
            SetGameState(GameState.Playing);
            _player.gameState = gameState;
            _player.level = level;
            Application.LoadLevel(level);
        }
        if (level == 2)
        {
            SetGameState(GameState.Playing);
            _player.gameState = gameState;
            _player.level = level;
            Application.LoadLevel(level);
        }
    }
    public void SetGMCheckPoint(GameObject point)
    {
        _player.checkPoint = point;
    }
    public GameObject GetGMCheckPoint()
    {
        return _player.checkPoint;
    }
    public void UpdatePlayerScore(int score)
    {
        _player.score = score;
        PrintPlayerInfo();
    }
    public void UpdatePlayerHealth(int health)
    {
        _player.health = health;
        if (health < 10)
        {
            SoundManager.instance.RandomizeSfx(playerHurt1, playerHurt2);
        }
    }
    public void UpdatePlayerLives(int lives)
    {
        _player.lives = lives;
    }
    public void UpdatePlayerLevel(int level)
    {
        _player.level = level;
        //PrintPlayerInfo();
    }
    public void OnDeathKillPlayer()
    {
        SoundManager.instance.RandomizeSfx(playerDeath1, playerDeath2);
        var player = FindObjectOfType<PlayerController>();
        Instantiate(deathPartical, player.transform.position, player.transform.rotation);
        Instantiate(playerDeath, player.transform.position, player.transform.rotation);

        var camera = FindObjectOfType<CameraController>();
        camera.isFollowing = false;

        Destroy(player.gameObject.transform.parent.gameObject);
        Destroy(player.gameObject.transform);
    }
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCR");
    }
    public IEnumerator RespawnPlayerCR()
    {

        yield
        return new WaitForSeconds(2);

        Instantiate(spawnPartical, _player.checkPoint.transform.position, _player.checkPoint.transform.rotation);
        var holder = new GameObject("Loaded_Player").transform;
        var player = Instantiate(playerAlive, _player.checkPoint.transform.position, _player.checkPoint.transform.rotation) as GameObject;
        player.transform.SetParent(holder);


        var camera = FindObjectOfType<CameraController>();
        camera.isFollowing = true;

    }
    public void GameOver()
    {
        //Load game over      
        Application.LoadLevelAsync(3);

        SetGameState(GameState.GameOver);
        _player.gameState = gameState;
        _player.level = Application.loadedLevel;
        //Debug.Log("Game Over");
    }
    private void PrintPlayerInfo()
    {
        Debug.Log(
            "Player Id: " + _player.id +
            "\nPlayer Score: " + _player.score +
            "\nPlayer Health: " + _player.health +
            "\nPlayer Lives: " + _player.lives +
            "\nPlayer Level: " + _player.level +
            "\nPlayer GameState: " + _player.gameState +
            "\nPlayer CheckPoint :" + _player.checkPoint +
            "\n\n");
    }
}