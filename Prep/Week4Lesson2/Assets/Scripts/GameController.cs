using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    //The variable you can access that references this class
    private static GameController _instance;

    //The way other classes are allowed to access the instance
    public static GameController GetInstance() { return GameController._instance; }

    public GameGUI gameGui;

    protected void Awake()
    {
        GameController gameController = GetInstance();
        if ( gameController != null )
        {
            //Destory the older GameController
            Destroy( gameController.gameObject );
        }
        else
        {
            GameController._instance = this;
        }
    }

    public void WinGame()
    {
        this.gameGui.ShowWinScreen();
    }
}
