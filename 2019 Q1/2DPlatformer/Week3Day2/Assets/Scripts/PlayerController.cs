using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    private Mover controlledMover;
    private Jumper controlledJumper;
    private Animator controlledAnimator;
    private Rigidbody2D controlledRigidBody;
    private GroundDetector controlledGroundDetector;

    public void Awake()
    {
        controlledMover = GetComponent<Mover>();
        controlledJumper = GetComponent<Jumper>();
        controlledAnimator = GetComponent<Animator>();
        controlledRigidBody = GetComponent<Rigidbody2D>();
        controlledGroundDetector = GetComponent<GroundDetector>();
    }


    void Update () 
    {
        controlledAnimator.SetBool("Walking", false);
        controlledAnimator.SetBool("IsOnGround", controlledGroundDetector.isOnGround);
        controlledAnimator.SetFloat("YVelocity", controlledRigidBody.velocity.y);

        if( Input.GetKey( KeyCode.RightArrow ) || Input.GetKey(KeyCode.D) )
        {
            controlledAnimator.SetBool("Walking", true);
            controlledMover.AccelerateInDirection( new Vector2(1f, 0f) );
        }

        if (Input.GetKey(KeyCode.LeftArrow ) || Input.GetKey(KeyCode.A) )
        {
            controlledAnimator.SetBool("Walking", true);
            controlledMover.AccelerateInDirection(new Vector2(-1f, 0f));
        }

        if( Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W) )
        {
            controlledJumper.Jump();
        }
    }
}
