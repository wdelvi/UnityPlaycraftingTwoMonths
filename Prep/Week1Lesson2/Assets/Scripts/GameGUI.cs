using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUI : MonoBehaviour 
{
    public GameObject winScreen;
    public GameObject player;

    public int numGoalsRequired = 3;

	// Use this for initialization
	public void Start () 
    {
        winScreen.SetActive( false ); 
	}
	
	public void Update () 
    {
        if ( DidWinGame() )
        {
            winScreen.SetActive( true );
        }
	}

    private bool DidWinGame()
    {
        if( player.GetComponent<PickupGetter>().GetPickupCount( PickupType.Goal ) >= numGoalsRequired )
        {
            return true;
        }

        return false;
    }
}
