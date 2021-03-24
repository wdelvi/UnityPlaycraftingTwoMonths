using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1f;

    public void MoveInDirection(Vector2 direction)
    {
        //Add the direction to our position
        this.transform.position += (Vector3)direction * speed;
    }
}
