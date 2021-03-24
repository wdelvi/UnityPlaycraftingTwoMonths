using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour 
{
    public bool wipeData = false;

    [HideInInspector]
    public int highScore = 0;

	// Use this for initialization
	void Awake () 
    {
        if( wipeData == false )
        {
            LoadData();
        }
	}
	
    public void SaveData( int newHighScore )
    {
        if( newHighScore > highScore )
        {
            highScore = newHighScore;
            PlayerPrefs.SetInt( "HighScore", highScore );
        }

        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        if( PlayerPrefs.HasKey( "HighScore" ) )
        {
            highScore = PlayerPrefs.GetInt( "HighScore" );
        }
    }
}
