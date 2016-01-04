using UnityEngine;

public class PickUpController : MonoBehaviour {

    private enum Pickups
    {
        BronzeCoin = 100,
        SilverCoin= 300,
        GoldCoin = 500               
    };

    public GameObject partical;

    private int pointsToAdd;
    public AudioClip pick1;
    public AudioClip pick2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {              
            switch (transform.tag)
            {
                case "BronzeCoin":
                    pointsToAdd = (int)Pickups.BronzeCoin;
                    break;
                case "SilverCoin":
                    pointsToAdd = (int)Pickups.SilverCoin;
                    break;
                case "GoldCoin":
                    pointsToAdd = (int)Pickups.GoldCoin;
                    break;
                default:
                    break;
            }

            SoundManager.instance.RandomizeSfx(pick1, pick2);
            Instantiate(partical, transform.position, transform.rotation);           
            GetComponent<Renderer>().enabled = false;
            ScoreManager.AddPoints(pointsToAdd);
            Destroy(gameObject);
        }
    }
}
