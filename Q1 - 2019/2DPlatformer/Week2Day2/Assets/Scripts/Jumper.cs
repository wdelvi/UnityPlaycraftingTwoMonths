using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour 
{
    public float jumpImpulse = 5f;
    public float jumpDelay = 0.5f;
    public float jumpMultiplier = 1f;
    public List<AudioClip> jumpSounds;

    private float lastTimeJumped;
    private float jumpBonusCounter;
    private bool jumpBonusIsActive;

    private float jumpBonusMultiplier = 1.5f;
    private float jumpBonusLength = 5f;

    private GroundDetector groundDetector;
    private AudioRandomizer audioRandomizer;

    public void Start()
    {
        groundDetector = GetComponent<GroundDetector>();
        audioRandomizer = GetComponent<AudioRandomizer>();
    }

    public void Update()
    {
        if (jumpBonusIsActive)
        {
            jumpBonusCounter += Time.deltaTime;

            if (jumpBonusCounter >= jumpBonusLength)
            {
                EndBonusMultiplier();
            }
        }
    }

    public void Jump()
    {
        float timeSinceJumped = Time.time - lastTimeJumped;
        
        if (timeSinceJumped >= jumpDelay && groundDetector.isOnGround)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x,jumpImpulse * jumpMultiplier);
            lastTimeJumped = Time.time;
            if (audioRandomizer)
            {
                audioRandomizer.PlayRandomSound(jumpSounds);
            }
        }
    }

    public void StartBonusMultiplier()
    {
        jumpBonusIsActive = true;
        jumpBonusCounter = 0f;
        jumpMultiplier = jumpBonusMultiplier;
    }

    private void EndBonusMultiplier()
    {
        jumpMultiplier = 1f;
        jumpBonusIsActive = false;
    }
}
