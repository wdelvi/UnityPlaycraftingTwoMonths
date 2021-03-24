using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject player;
    public Text scoreText;
    public Text highScoreText;

    public List<GameObject> hitPointIndicators;

    private DataController dataController;
    private int highScore;

    // Use this for initialization
    void Start()
    {
        dataController = GetComponent<DataController>();

        if( dataController != null )
        {
            highScore = dataController.highScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( player == null )
        {
            loseScreen.SetActive( true );
            UpdateHealthCount( 0 );
            return;
        }

        UpdateScore();

        UpdateHealthCount( player.GetComponent<Destructible>().hitPoints );
    }

    private void UpdateHealthCount( int hitPoints )
    {
        //Remember that this is pretty innefficent!

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

    private void UpdateScore()
    {
        int newScore = ( int ) player.transform.position.x;
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

        if( dataController != null )
        {
            dataController.SaveData( newScore );
        }
    }
}
