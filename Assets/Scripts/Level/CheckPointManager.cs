using UnityEngine;

public class CheckPointManager : GMBase{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            GM.SetGMCheckPoint(gameObject);
            //Debug.Log(transform.position);
        }
    }
}
