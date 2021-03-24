using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndGame : MonoBehaviour
{
    public string textToDisplay;
    public GameController gameController;

    //This function automatically happens when two objects that both have a collider2D with the trigger box checked and one has a rigidbody collide
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //When this thing touches the goal line, tell the Game Controller to end the game
        gameController.EndGame(textToDisplay);
    }
}
