using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUI : MonoBehaviour 
{
    public Animator winScreen;

    public void ShowWinScreen()
    {
        winScreen.SetTrigger( "Show" );
    }
}
