using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour 
{
    public GameObject loseScreen;
    public GameObject player;
    public Text scoreText;

    public List<GameObject> hitPointIndicators;

    private int highScore;

	// Use this for initialization
	void Start () 
    {
        loseScreen.SetActive( false );	
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
