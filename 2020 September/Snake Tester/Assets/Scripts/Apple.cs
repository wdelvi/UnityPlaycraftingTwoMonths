using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sometimes we need to import other code, like for the Text object
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    //This text box will update every time the apple gets touched
    public Text scoreText;

    //This is where we put the TrailRenderer from the player so that we can make it's trail longer when we get an apple
    public TrailRenderer playerTrailRenderer;

    public float respawnBounds;
    public int score;

    //Start happens one time when the game begins
    public void Start()
    {
        ChooseRandomPosition();
        score = 0;
    }

    //On collision enter 2D happens whenever we get touched
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //When we touch the apple, set it to a new position, add 1 to our score, and update what the score text says
        ChooseRandomPosition();
        score += 1;
        scoreText.text = "SCORE: " + score;
        playerTrailRenderer.time = score * 0.5f;
    }

    //Custom functions like this one happen only when we tell them to
    private void ChooseRandomPosition()
    {
        //We can choose a random number by saying Random.Range(smallestPossibleNumber, largestPossibleNumber)
        float randomXPosition = Random.Range(-respawnBounds, respawnBounds);
        float randomyPosition = Random.Range(-respawnBounds, respawnBounds);

        //Then we set our position to the new spot!
        this.transform.position = new Vector2(randomXPosition, randomyPosition);
    }
}
