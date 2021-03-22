using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private Jumper jumper;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mover = GetComponent<Mover>();
        jumper = GetComponent<Jumper>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if( Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) )
        {
            mover.AccelerateInDirection(new Vector2(-1f, 0f));
            animator.SetBool("Walking", true);
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            mover.AccelerateInDirection(new Vector2(1f, 0f));
            animator.SetBool("Walking", true);
            spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            jumper.Jump();
            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            animator.ResetTrigger("Jump");
        }

        if ( Input.anyKey == false )
        {
            //I will always trigger when nothing is pressed
            animator.SetBool("Walking", false);
        }
    }
}
