using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameOnTouch : MonoBehaviour 
{
    private void OnCollisionEnter( Collision collision )
    {
        string collisionTag = collision.collider.tag;

        if( collisionTag.Equals( "Player" ) )
        {
            GameController.GetInstance().WinGame();
        }
    }
}
