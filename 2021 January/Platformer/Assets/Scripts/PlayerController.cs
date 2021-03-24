using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(ProjectileShooter))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private Jumper jumper;
    private Animator animator;
    private ProjectileShooter projectileShooter;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        jumper = GetComponent<Jumper>();
        animator = GetComponent<Animator>();
        projectileShooter = GetComponent<ProjectileShooter>();

        if (projectileShooter != null)
        {
            projectileShooter.SetDirection(new Vector2(-1, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Moving Left
        if( Input.GetKey( KeyCode.LeftArrow ) || Input.GetKey(KeyCode.A))
        {
            mover.AccelerateInDirection(new Vector2(-1, 0));
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z);

            animator.SetBool("walking", true);

            if (projectileShooter != null)
            {
                projectileShooter.SetDirection(new Vector2(-1, 0));
            }
        }

        //Moving Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            mover.AccelerateInDirection(new Vector2(1, 0));
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);

            animator.SetBool("walking", true);

            if (projectileShooter != null)
            {
                projectileShooter.SetDirection(new Vector2(1, 0));
            }
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            jumper.Jump();
        }

        //Not doing anything
        if(Input.anyKey == false)
        {
            animator.SetBool("walking", false);
        }
    }
}
