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

    public void OnTriggerEnter2D( Collider2D otherCollider )
    {
        DoCollision( otherCollider );
    }

    public void OnTriggerExit2D( Collider2D otherCollider )
    {
        DoCollision( otherCollider );
    }

    private void DoCollision( Collider2D otherCollider )
    {
        PickupGetter getter = otherCollider.GetComponent<PickupGetter>();

        if( getter != null )
        {
            PickUp( getter );
        }
    }
}
