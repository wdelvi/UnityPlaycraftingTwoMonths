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

    public void PickUp( PickupGetter pickupGetter )
    {
        pickupGetter.PickUp( pickupType );
        Destroy( gameObject );
    }

    public void OnTriggerEnter2D( Collider2D collision )
    {
        DoCollision( collision );
    }

    private void DoCollision( Collider2D otherCollider )
    {
        PickupGetter pickupGetter = otherCollider.GetComponent<PickupGetter>();

        if( pickupGetter != null )
        {
            PickUp( pickupGetter );
        }
    }
}
