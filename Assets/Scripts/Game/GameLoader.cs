using UnityEngine;

public class GameLoader : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject soundManager;

    // Use this for initialization
    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        if (SoundManager.instance == null)
        {
            Instantiate(soundManager);
        }
    }
}
