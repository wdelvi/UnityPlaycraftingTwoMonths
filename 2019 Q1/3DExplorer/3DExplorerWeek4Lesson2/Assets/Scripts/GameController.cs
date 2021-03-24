using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    public GameGUI gameGUI;
    public PickupGetter playerPickupGetter;

    private static GameController instance;

    public static GameController GetInstance()
    {
        return instance;
    }

    public void Awake()
    {
        GameController gameController = GetInstance();

        if( gameController )
        {
            Destroy( gameController.gameObject );
        }
        else
        {
            GameController.instance = this;
        }
    }

    public void WinGame()
    {
        gameGUI.ShowWinScreen();
    }
}
