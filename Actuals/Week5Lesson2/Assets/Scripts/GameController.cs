using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    private static GameController _instance;

    public static GameController GetInstance() { return GameController._instance; }

    public GameGUI gameGUI;

    private void Awake()
    {
        GameController gameController = GetInstance();
        if( gameController != null )
        {
            Destroy( gameController.gameObject );
        }
        else
        {
            GameController._instance = this;
        }
    }

    public void WinGame()
    {
        this.gameGUI.ShowWinScreen();
    }
}
