using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [HideInInspector]
    public bool onGround = false;

    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        onGround = true;

        if(animator)
        {
            animator.SetBool("OnGround", true);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;

        if (animator)
        {
            animator.SetBool("OnGround", false);
        }
    }


}
