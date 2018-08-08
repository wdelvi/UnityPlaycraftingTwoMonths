using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour 
{
    [HideInInspector]
    public bool isOnGround;

    private Animator animator;

	public void Start () 
    {
        isOnGround = false;
        animator = GetComponent<Animator>();
	}

    public void OnCollisionEnter2D( Collision2D collision )
    {
        if( collision.collider.gameObject.layer == 8 )
        {
            isOnGround = true;

            if( animator )
            {
                animator.SetBool( "IsOnGround", isOnGround );
            }
        }
    }

    public void OnCollisionExit2D( Collision2D collision )
    {
        if( collision.collider.gameObject.layer == 8 )
        {
            isOnGround = false;

            if ( animator )
            {
                animator.SetBool( "IsOnGround", isOnGround );
            }
        }
    }
}
