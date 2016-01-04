using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : GMStaticBase
{

    private Text text;
    public static int score;

    void Start()
    {
        base.Init();   
        text = GetComponent<Text>();
        if (GM._player.score != 0)
        {
            score = GM._player.score;
        }
        else
        {
            ResetScore();
        }
    }    
    void Update()
    {
        if (score >= 0)
        {
            text.text = "" + score;
        }       
    }
    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        GM.UpdatePlayerScore(score);
    }

    public static void TakePoints(int pointsToAdd)
    {
        score -= pointsToAdd;
        GM.UpdatePlayerScore(score);
    }
    public static void ResetScore()
    {
        score = 0;
        GM.UpdatePlayerScore(score);
    }
}
