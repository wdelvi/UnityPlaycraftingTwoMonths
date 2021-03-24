using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private int score;
    public Text scoreText;

    private int highScore;
    public Text highScoreText;

    private string highScoreKey = "highScoreKey";

    public bool wipeData = false;

    public void Start()
    {
        if( wipeData == true )
        {
            //Deletes every single high score key
            PlayerPrefs.DeleteAll();

            //Deletes one specific key. You do not need both.
            PlayerPrefs.DeleteKey(highScoreKey);
        }

        AddScore(0);

        if (PlayerPrefs.HasKey(highScoreKey))
        {
            highScore = PlayerPrefs.GetInt(highScoreKey);
            highScoreText.text = "HIGH SCORE: " + highScore;
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "SCORE: " + score;

        if( score > highScore )
        {
            highScore = score;

            //This is where I might reward the player for a high score
            PlayerPrefs.SetInt(highScoreKey, highScore);
            PlayerPrefs.Save();

            highScoreText.text = "HIGH SCORE: " + highScore;
        }
    }
}
