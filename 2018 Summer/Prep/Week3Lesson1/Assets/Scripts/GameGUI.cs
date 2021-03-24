using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour 
{
    public GameObject loseScreen;
    public GameObject newHighScoreScreen;
    public GameObject player;
    public Text scoreText;
    public Text highScoreText;

    public List<GameObject> hitPointIndicators;

    public int minimumHighScore;

    private int highScore;
    private DataController dataController;
    private bool hasSetNewHighScore = false;

	// Use this for initialization
	void Start () 
    {
        loseScreen.SetActive( false );
        newHighScoreScreen.SetActive( false );

        dataController = GetComponent<DataController>();

        if ( dataController != null )
        {
            highScore = dataController.highScore;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if( player == null )
        {
            loseScreen.SetActive( true );
            UpdateHealthCount( 0 );
            return;
        }

        UpdateScore();

        UpdateHealthCount( player.GetComponent<Destructible>().hitPoints );
	}

    private void UpdateScore()
    {
        int newScore = ( int )Mathf.Round( player.transform.position.x );
        scoreText.text = "Score: " + newScore;

        if( newScore > highScore )
        {
            NewHighScore( newScore );
        }

        highScoreText.text = "High Score: " + highScore;
    }

    private void NewHighScore( int newScore )
    {
        highScore = newScore;

        if ( dataController != null )
        {
            dataController.SaveData( newScore );
        }

        if ( hasSetNewHighScore == false && newScore > minimumHighScore )
        {
            hasSetNewHighScore = true;
            newHighScoreScreen.SetActive( true );
            newHighScoreScreen.GetComponent<Animator>().SetTrigger( "Show" );
        }
    }

    private void UpdateHealthCount( int hitPoints )
    {
        if ( hitPointIndicators.Count <= 0 )
        {
            return;
        }

        for ( int i = 0; i < hitPointIndicators.Count; i++ )
        {
            if ( i < hitPoints )
            {
                hitPointIndicators[ i ].SetActive( true );
            }
            else
            {
                hitPointIndicators[ i ].SetActive( false );
            }
        }
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene( scene.name );
    }
}
