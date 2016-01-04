using UnityEngine;

public class GMStaticBase : MonoBehaviour {

    private static GameManager gm;
    public static GameManager GM
    {
        get { return gm; }
        set { gm = value; }
    }
    void Start()
    {
        Init();
    }
    protected virtual void Init()
    {
        gm = GameManager.instance.GetComponent<GameManager>();
    }
}
