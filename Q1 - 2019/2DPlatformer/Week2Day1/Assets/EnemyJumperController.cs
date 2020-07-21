using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumperController : MonoBehaviour 
{
    public Jumper controlledJumper;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controlledJumper.Jump();
    }
}
