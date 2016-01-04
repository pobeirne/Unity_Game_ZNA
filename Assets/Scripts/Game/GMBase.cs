using UnityEngine;

public class GMBase : MonoBehaviour {

    private GameManager gm;
    public GameManager GM
    {
        get { return gm; }
        set { gm = value; }
    }
    void Start()
    {
        gm = GameManager.instance.GetComponent<GameManager>();
    }  
}
