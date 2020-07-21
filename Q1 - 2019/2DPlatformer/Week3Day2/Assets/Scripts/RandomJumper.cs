using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomJumper : MonoBehaviour 
{
    public float minJumpDelay = 1f;
    public float maxJumpDelay = 3f;
    public bool randomizedJumps = true;

    private float jumpCounter;
    private float timeToJump;
    private Jumper controlledJumper;

	// Use this for initialization
	void Start () 
    {
        controlledJumper = GetComponent<Jumper>();
        jumpCounter = 0f;
        timeToJump = Random.Range(minJumpDelay, maxJumpDelay);
    }
	
	// Update is called once per frame
	void Update () 
    {
        jumpCounter += Time.deltaTime;

        if( jumpCounter >= timeToJump )
        {
            controlledJumper.Jump();
            jumpCounter = 0f;

            if (randomizedJumps)
            {
                timeToJump = Random.Range(minJumpDelay, maxJumpDelay);
            }
        }
    }
}
