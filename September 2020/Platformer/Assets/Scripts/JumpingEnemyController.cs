using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Animator))]

public class JumpingEnemyController : MonoBehaviour
{
    public float timeBetweenJumps = 5f;

    private float jumpTimer;
    private Jumper jumper;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        jumper = GetComponent<Jumper>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpTimer += Time.deltaTime;

        if(jumpTimer >= timeBetweenJumps)
        {
            jumper.Jump();
            jumpTimer = 0f;
            animator.SetTrigger("Jump");
        }
    }
}
