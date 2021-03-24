using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //The position for this boat to move towards
    public Vector2 moveTo;
    //The speed at which this boat will move towards that position
    public float speed = 0.1f;

    
    // Update is called once per frame, up to 60 times a second
    void Update()
    {
        //A temporary variable to store our new position, moved just a little bit
        Vector3 newPosition = transform.position;

        //If our current X position is smaller than our MoveTo's X position, make our X position larger
        if ( transform.position.x < moveTo.x  )
        {
            newPosition.x += speed;
        }
        //If our current X position is larger than our MoveTo's X position, make our X position smaller
        else if (transform.position.x > moveTo.x)
        {
            newPosition.x -= speed;
        }

        //If our current Y position is smaller than our MoveTo's Y position, make our Y position larger
        if (transform.position.y < moveTo.y)
        {
            newPosition.y += speed;
        }
        //If our current Y position is larger than our MoveTo's Y position, make our Y position smaller
        else if (transform.position.y > moveTo.y)
        {
            newPosition.y -= speed;
        }

        //Set our current position equal to the temporary variable we edited
        transform.position = newPosition;
    }
}
