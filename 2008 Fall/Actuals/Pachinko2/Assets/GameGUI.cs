using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour 
{
    public PointCollector pointCollector;
    public Text scoreText;

	// Use this for initialization
	void Start () 
    {
        if ( scoreText )
        {
            scoreText.text = "Score: 0";
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if ( scoreText )
        {
            scoreText.text = "Score: " + pointCollector.GetPoints();
        }
	}

    public void LoadScene( string sceneName )
    {
        SceneManager.LoadScene( sceneName );
    }
}
