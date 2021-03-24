using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour 
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject player;

    public List<GameObject> goalIndicators;
    public List<GameObject> hitPointIndicators;

	// Use this for initialization
	void Start () 
    {
        winScreen.SetActive( false );	
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

        UpdateHealthCount( player.GetComponent<Destructible>().hitPoints );

        UpdateGoalCount();

	    if( DidWinGame() )
        {
            winScreen.SetActive( true );
        }
	}

    private void UpdateGoalCount()
    {
        //Remember that this is pretty innefficent!

        int numGoalsCollected = player.GetComponent<PickupGetter>().GetPickupCount( PickupType.Goal );

        for ( int i = 0; i < goalIndicators.Count; i++ )
        {
            if ( i < numGoalsCollected )
            {
                goalIndicators[ i ].SetActive( true );
            }
            else
            {
                goalIndicators[ i ].SetActive( false );
            }
        }
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

    private bool DidWinGame()
    {
        if( player.GetComponent<PickupGetter>().GetPickupCount( PickupType.Goal ) >= goalIndicators.Count )
        {
            return true;
        }

        return false;
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene( scene.name );
    }
}
