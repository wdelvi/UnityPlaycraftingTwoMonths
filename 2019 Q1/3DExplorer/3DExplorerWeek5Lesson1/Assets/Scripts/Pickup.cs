using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Goal,
    JumpBonus
}

public class Pickup : MonoBehaviour 
{
    public PickupType pickupType;

    private void OnTriggerEnter(Collider collision)
    {
        PickupGetter touchedPickupGetter = collision.GetComponent<PickupGetter>();

        if (touchedPickupGetter)
        {
            PickUp(touchedPickupGetter);
        }
    }

    private void PickUp( PickupGetter pickupGetter )
    {
        pickupGetter.PickUp(pickupType);
        Destroy(gameObject);
    }
}
