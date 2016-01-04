using UnityEngine;

public class DestroyObjectOverTime : MonoBehaviour
{
    public float lifetime;

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnBecameInvisable()
    {
        Destroy(gameObject);
    }
}
