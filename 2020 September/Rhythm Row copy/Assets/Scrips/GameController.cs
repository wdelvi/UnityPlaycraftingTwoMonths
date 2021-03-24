using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //The amount to move our boat forward when correct
    public float xMovePerCorrect = 0.25f;
    //The amount to move our boat backwards when incorrect
    public float xMovePerIncorrect = -0.05f;

    //The time in bewteen every beat
    public float timePerBeat = 0.5f;

    //Public refernce varibles (Anything that is a componenet) need to be set in the inspector!
    public AudioSource mainAudioSoure;
    public Mover playerMover;
    public Mover enemyMover;
    public Text feedbackText;

    //Private variables don't appear in the inspector
    private float beatTimer;
    private bool gameRunning = true;

    // Start is called at the very beginning of the game
    void Start()
    {
        //When we first start our game, reset our beat timer, and play our first beat sound
        mainAudioSoure.Play();
        beatTimer = 0f;
    }

    // Update is called once per frame, up to 60 times per second
    void Update()
    {
        //If our game isn't running, return, therfore ignoring everything else in this function
        if(gameRunning == false)
        {
            return;
        }

        //If we press space, do something
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //If our input is on beat, do goo things
            if(IsGoodInput())
            {
                //Show good display text
                feedbackText.text = "Good!";
                //Move player forward
                playerMover.moveTo = new Vector2(playerMover.moveTo.x, playerMover.moveTo.y + xMovePerCorrect);
            }
            //If our input is not on beat, do bad things
            else
            {
                //Show bad display text
                feedbackText.text = "Bad";
                //Move player backwards
                playerMover.moveTo = new Vector2(playerMover.moveTo.x, playerMover.moveTo.y + xMovePerIncorrect);
            }
        }

        //Increment the beatTimer by Time.deltaTime. This essentially just creates a timer
        beatTimer += Time.deltaTime;

        //If it has been 0.5 seconds (or howeever long timePerBeat is) play new sound, and start timer over
        if( beatTimer >= timePerBeat )
        {
            mainAudioSoure.Play();
            beatTimer = 0f;
        }
    }

    private bool IsGoodInput()
    {
        //If we are late, within the first 20% of the time since the last beat played, that's good enough to count as a hit
        if (beatTimer > 0f && beatTimer < timePerBeat * 0.2f)
        {
            return true;
        }

        //If we are early, withint the last 20% of the time before the next beat is played, that's good enough to count as a hit
        if (beatTimer > timePerBeat * 0.8f && beatTimer < timePerBeat * 1f)
        {
            return true;
        }

        //Otherwise, the other 60%, counts as a bad hit
        return false;
    }

    public void EndGame( string displayText )
    {
        //Update the gameRunning variable so the update loop will stop happening
        gameRunning = false;

        //Set the player and enemy's moveTo position to their current postiion, effectively freezing them
        playerMover.moveTo = playerMover.transform.position;
        enemyMover.moveTo = enemyMover.transform.position;

        //Show the end game text
        feedbackText.text = displayText;
    }
}
