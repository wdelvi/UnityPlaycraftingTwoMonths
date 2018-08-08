using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGetter : MonoBehaviour
{
    protected List<PickupType> pickups;

    public void Awake()
    {
        pickups = new List<PickupType>();
    }

    public void PickUp( PickupType pickupType )
    {
        pickups.Add( pickupType );

        if( pickupType == PickupType.JumpBonus )
        {
            if( GetComponent<Jumper>() )
            {
                GetComponent<Jumper>().ApplyJumpBonus();
            }
        }
        if( pickupType == PickupType.Goal )
        {
            Debug.Log( "You Win!" );
        }
    }

    public int GetPickupCount( PickupType pickupType )
    {
        int count = 0;

        for ( int i = 0; i < pickups.Count; i++ )
        {
            if ( pickups[ i ] == pickupType )
            {
                count++;
            }
        }

        Debug.Log( count );

        return count;
    }
}

