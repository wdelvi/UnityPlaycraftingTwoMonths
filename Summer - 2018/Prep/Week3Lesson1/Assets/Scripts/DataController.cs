using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour 
{
    public bool wipeData = false;

    [HideInInspector]
    public int highScore = 0;

    private string highScoreKey = "HighScore";

    public void Awake()
    {
        if( wipeData == false )
        {
            LoadData();
        }
    }

    public void SaveData( int newHighScore )
    {
        if ( newHighScore > highScore )
        {
            highScore = newHighScore;
            PlayerPrefs.SetInt( highScoreKey, newHighScore );
        }

        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        if( PlayerPrefs.HasKey( highScoreKey ) )
        {
            highScore = PlayerPrefs.GetInt( highScoreKey );
        }
    }
}
