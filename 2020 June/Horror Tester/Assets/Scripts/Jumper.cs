using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float jumpImpulse = 5f;

    public float jumpImpulseModifier = 1f;

    private bool isOnGround;

    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (isOnGround == true)
        {
            myRigidbody.velocity =
                new Vector2(myRigidbody.velocity.x, jumpImpulse * jumpImpulseModifier);
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        isOnGround = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        isOnGround = false;
    }

    public bool GetIsOnGround()
    {
        return isOnGround;
    }

    public void StartJumpBonus( float newJumpModifier, float bonusLength )
    {
        jumpImpulseModifier = newJumpModifier;
        CancelInvoke();
        Invoke("EndJumpBonus", bonusLength);
    }

    public void EndJumpBonus()
    {
        jumpImpulseModifier = 1f;
    }
}
