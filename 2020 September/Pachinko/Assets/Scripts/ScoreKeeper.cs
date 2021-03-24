using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    public bool wipeSavedData = false;

    public Text textBox;
    public Text highScoreText;

    private int score;
    private int highScore;

    private string highScoreKey = "highScore";
    private string currentLevelHighScoreKey;

    public void Start()
    {
        currentLevelHighScoreKey = highScoreKey + SceneManager.GetActiveScene().name;

        if (wipeSavedData)
        {
            PlayerPrefs.DeleteKey(currentLevelHighScoreKey);
        }

        //The player prefs checks if this key exists, and then sets it to the variable highSCore
        if ( PlayerPrefs.HasKey(currentLevelHighScoreKey) )
        {
            highScore = PlayerPrefs.GetInt(currentLevelHighScoreKey);
        }

        textBox.text = "SCORE: " + score;
        highScoreText.text = "HIGH SCORE: " + highScore;
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;

        textBox.text = "SCORE: " + score;

        //Set high score to score, if the score is greater than high score
        if( score > highScore )
        {
            highScore = score;

            //We first must set all player prefs, and then save them once to actually write to the file
            PlayerPrefs.SetInt(currentLevelHighScoreKey, highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = "HIGH SCORE: " + highScore;
    }
}
