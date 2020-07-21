using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteVelocityFlipper : MonoBehaviour 
{
    public bool deafultIsRightFacing = true;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D controlledRigidbody;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        controlledRigidbody = GetComponent<Rigidbody2D>();
    }

	void Update () 
    {
        bool flip = controlledRigidbody.velocity.x < 0f;

        if(controlledRigidbody.velocity.x < 0.1f && controlledRigidbody.velocity.x > -0.1f)
        {
            return;
        }

        if( !deafultIsRightFacing )
        {
            flip = !flip;
        }

        spriteRenderer.flipX = flip;
	}
}
