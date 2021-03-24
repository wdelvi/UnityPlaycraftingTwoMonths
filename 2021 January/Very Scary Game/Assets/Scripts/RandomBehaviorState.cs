using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBehaviorState : BehaviorState
{
    private Vector3 moveTo;

    public float timeBetweenNewMoveTo = 3f;
    public float maxMoveToDistance = 10f;

    private float newMoveToTimer;
    private Animator animator;
    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();

        PickRandomMoveTo();
    }

    public override void Tick()
    {
        base.Tick();

        newMoveToTimer += Time.deltaTime;

        if(newMoveToTimer > timeBetweenNewMoveTo)
        {
            PickRandomMoveTo();
        }

        MoveTowardsPosition(moveTo);

        if(animator != null)
        {
            animator.SetFloat("speed", myRigidbody.velocity.magnitude);
        }
    }

    private void PickRandomMoveTo()
    {
        newMoveToTimer = 0f;

        Vector3 newMoveTo = transform.position;

        newMoveTo.x += Random.Range(-maxMoveToDistance, maxMoveToDistance);
        newMoveTo.z += Random.Range(-maxMoveToDistance, maxMoveToDistance);

        moveTo = newMoveTo;
    }
}
