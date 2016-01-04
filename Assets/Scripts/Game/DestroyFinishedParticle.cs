using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour
{

    private ParticleSystem thisParticleSystem;

    // Use this for initialization
    void Start()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (thisParticleSystem.isPlaying)
        {
            return;
        }

        Destroy(gameObject);
    }

    void OnBecameInvisable()
    {
        Destroy(gameObject);
    }
}
