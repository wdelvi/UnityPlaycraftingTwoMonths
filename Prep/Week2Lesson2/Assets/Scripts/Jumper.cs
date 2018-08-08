using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour 
{
    public float jumpImpulse = 2.5f;

    public float jumpDelay = 0.5f;

    public float jumpBonusMultiplier = 1.5f;

    public List<AudioClip> jumpSounds;

    private float lastTimeJumped;
    private GroundDetector groundDetector;

    public void Awake()
    {
        groundDetector = GetComponent<GroundDetector>();
    }

    public void Jump()
    {
        float timeSinceJumped = Time.time - lastTimeJumped;

        if ( timeSinceJumped >= jumpDelay && groundDetector.isOnGround )
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2( 0.0f, jumpImpulse );

            lastTimeJumped = Time.time;

            if( GetComponent<AudioRandomizer>() )
            {
                GetComponent<AudioRandomizer>().PlayRandomSound( jumpSounds );
            }
        }
    }

    public void ApplyJumpBonus()
    {
        jumpImpulse *= jumpBonusMultiplier;
    }
}
