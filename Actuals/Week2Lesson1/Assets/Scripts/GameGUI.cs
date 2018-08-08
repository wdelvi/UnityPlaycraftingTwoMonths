using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour 
{
    public GameObject winScreen;
    public GameObject player;

    public List<GameObject> goalIndicators;
    public List<GameObject> filledHealthObjects;

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
            for ( int i = 0; i < filledHealthObjects.Count; i++ )
            {
                filledHealthObjects[ i ].SetActive( false );
            }

            return;
        }

        UpdateGoalCount();

        UpdateHealthCount();

	    if( DidWinGame() )
        {
            winScreen.SetActive( true );
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

    private void UpdateGoalCount()
    {
        int numGoalsCollected = player.GetComponent<PickupGetter>().GetPickupCount( PickupType.Goal );

        for ( int i = 0; i < goalIndicators.Count; i++ )
        {
            if( i < numGoalsCollected )
            {
                goalIndicators[ i ].SetActive( true );
            }
            else
            {
                goalIndicators[ i ].SetActive( false );
            }
        }
    }

    private void UpdateHealthCount()
    {
        int hitPoints = player.GetComponent<Destructible>().hitPoints;

        for ( int i = 0; i < filledHealthObjects.Count; i++ )
        {
            if ( i < hitPoints )
            {
                filledHealthObjects[ i ].SetActive( true );
            }
            else
            {
                filledHealthObjects[ i ].SetActive( false );
            }
        }
    }
    
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene( scene.name );
    }
}
