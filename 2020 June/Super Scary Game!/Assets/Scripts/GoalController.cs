using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Won Game");
    }
}
