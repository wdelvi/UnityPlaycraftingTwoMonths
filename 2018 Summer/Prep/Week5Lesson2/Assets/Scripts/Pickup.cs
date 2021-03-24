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

    public void PickUp( PickupGetter getter )
    {
        getter.PickUp( pickupType );
        Destroy( gameObject );
    }

    public void OnTriggerEnter( Collider otherCollider )
    {
        DoCollision( otherCollider );
    }

    public void OnTriggerExit( Collider otherCollider )
    {
        DoCollision( otherCollider );
    }

    private void DoCollision( Collider otherCollider )
    {
        PickupGetter getter = otherCollider.GetComponent<PickupGetter>();

        if( getter != null )
        {
            PickUp( getter );
        }
    }
}
