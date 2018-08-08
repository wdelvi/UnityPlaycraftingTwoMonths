using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUI : MonoBehaviour 
{
    public GameObject winScreen;
    public GameObject player;

    public int numGoalsRequired = 3;

	// Use this for initialization
	void Start () 
    {
        winScreen.SetActive( false );	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if( DidWinGame() )
        {
            winScreen.SetActive( true );
        }
	}

    private bool DidWinGame()
    {
        if( player != null && 
           player.GetComponent<PickupGetter>().GetPickupCount( PickupType.Goal ) >= numGoalsRequired )
        {
            return true;
        }

        return false;
    }
}
