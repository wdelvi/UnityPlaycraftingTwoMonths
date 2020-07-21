using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUI : MonoBehaviour 
{
    public int goalCountToWin;
    public GameObject winScreen;
    public PickupGetter playerPickupGetter;

	// Use this for initialization
	void Start () 
    {
        winScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if( playerPickupGetter.GetPickupCount( PickupType.Goal ) >= goalCountToWin )
        {
            winScreen.SetActive(true);
        }
	}
}
