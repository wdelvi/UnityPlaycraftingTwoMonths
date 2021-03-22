using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    //this is a reference variable
    //It lets the Snake talk to its Mover
    public Mover Mover;

    private Vector2 directionToMove;

    // Update is called once per frame, about 60 times a second
    void Update()
    {
        //Input.GetKey checks if the given key is currently pressed
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //Whenever we hit a key, we change which direction we should move
            directionToMove = new Vector2(-1f, 0f);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            directionToMove = new Vector2(1f, 0f);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            directionToMove = new Vector2(0f, 1f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            directionToMove = new Vector2(0f, -1f);
        }

        //We always move in a certain direction
        //This is how we tell the mover to that direction
        Mover.MoveInDirection(directionToMove);
    }
}
