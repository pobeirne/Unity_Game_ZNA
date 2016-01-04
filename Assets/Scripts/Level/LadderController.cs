using UnityEngine;
public class LadderController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<PlayerController>().isOnLadder = true;
            Debug.Log("Enter");
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<PlayerController>().isOnLadder = false;
            Debug.Log("Exit");
        }

    }
}
