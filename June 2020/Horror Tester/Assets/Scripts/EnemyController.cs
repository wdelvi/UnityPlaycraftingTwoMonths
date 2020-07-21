using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;

    private Mover mover;
    private Rotator rotator;

    // Start is called before the first frame update
    void Start()
    {
        mover = gameObject.GetComponent<Mover>();
        rotator = gameObject.GetComponent<Rotator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            mover.AccelerateInDirection(player.position - transform.position);
            rotator.RotateTowardsDirection(player.position - transform.position);
        }
    }
}
