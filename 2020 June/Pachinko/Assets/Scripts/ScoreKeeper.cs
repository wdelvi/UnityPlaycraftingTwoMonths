using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public string highScorePlayerPref;

    public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = 0;

        if( PlayerPrefs.HasKey(highScorePlayerPref) )
        {
            highScore = PlayerPrefs.GetInt(highScorePlayerPref);
        }
    }

    public void AddPoints( int pointsToAdd )
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score;

        if( score > highScore )
        {
            highScore = score;

            PlayerPrefs.SetInt(highScorePlayerPref, highScore);
            PlayerPrefs.Save();
        }
    }
}
