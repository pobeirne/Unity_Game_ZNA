using UnityEngine;

public class CheckPointFlagManager : MonoBehaviour
{

    //Animation
    private Animator animator;
    public GameObject partical;
    private bool isActive;

    void Start()
    {
        animator = GetComponent<Animator>();
        isActive = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if (!isActive)
            {
                Instantiate(partical, transform.position, transform.rotation);
                isActive = true;
                animator.SetBool("Activated", isActive);
            }
        }
    }
}
