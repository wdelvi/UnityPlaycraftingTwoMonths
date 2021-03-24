using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour 
{
    private PlayerController playerController;

	// Use this for initialization
	void Start () 
    {
        playerController = GetComponent<PlayerController>();	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if( playerController == null )
        {
            return;
        }

        playerController.MoveRight();
	}
}
