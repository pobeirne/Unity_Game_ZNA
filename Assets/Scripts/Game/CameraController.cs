using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    public bool isFollowing;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();       
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            isFollowing = true;
        }
        else
        {
            player = FindObjectOfType<PlayerController>();
        }

        if (isFollowing)
        {           
            transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, 0f, 54.1f),
                                              transform.position.y,
                                              transform.position.z
                                              );
            //Debug.Log("Resolution is " + Screen.width + "x" + Screen.height);
        }
    }

    //public void SetCameraPosition(Vector3 position)
    //{
    //    isFollowing = false;

    //    transform.position = position;

    //    isFollowing = true;
    //}
}
