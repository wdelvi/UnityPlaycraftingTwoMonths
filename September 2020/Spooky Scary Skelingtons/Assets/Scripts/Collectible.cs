using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectibleType
{
    GoalMarkers,
    HealthObject,
    JumpBonus,
    InvicibilityBonus
}

[RequireComponent(typeof(Collider))]
public class Collectible : MonoBehaviour
{
    public CollectibleType collectibleType;

    public void Collect( Collector collector )
    {
        collector.Collect(collectibleType);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider collision)
    {
        Collector collector = collision.GetComponent<Collector>();

        if(collector)
        {
            Collect(collector);
        }
    }
}
