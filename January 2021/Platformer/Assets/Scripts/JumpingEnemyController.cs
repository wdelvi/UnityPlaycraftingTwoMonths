using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Jumper))]
public class JumpingEnemyController : MonoBehaviour
{
    [Tooltip("The enemy will jump every X seconds")]
    public float timeBetweenJumps = 5f;

    private float jumpTimer;
    private Jumper jumper;

    // Start is called before the first frame update
    void Start()
    {
        jumper = GetComponent<Jumper>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpTimer += Time.deltaTime;

        if(jumpTimer >= timeBetweenJumps)
        {
            jumpTimer = 0f;
            jumper.Jump();
        }
    }
}
