using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameOnTouch : MonoBehaviour 
{
    public void OnCollisionEnter( Collision collision )
    {
        GameController.GetInstance().WinGame();
    }
}
