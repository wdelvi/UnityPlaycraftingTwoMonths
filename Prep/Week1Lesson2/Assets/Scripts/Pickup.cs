using UnityEngine;

public enum PickupType
{
    Goal,
    JumpBonus
}

public class Pickup : MonoBehaviour
{
    public PickupType pickupType;

    public virtual void PickUp( PickupGetter getter )
    {
        getter.PickUp( pickupType );
        Destroy( gameObject );
    }

    public virtual void OnTriggerEnter2D( Collider2D other )
    {
        DoCollision( other );
    }
    public virtual void OnTriggerStay2D( Collider2D other )
    {
        DoCollision( other );
    }

    protected virtual void DoCollision( Collider2D other )
    {
        PickupGetter getter = other.GetComponent<PickupGetter>();

        if ( getter != null )
        {
            PickUp( getter );
        }
    }
}