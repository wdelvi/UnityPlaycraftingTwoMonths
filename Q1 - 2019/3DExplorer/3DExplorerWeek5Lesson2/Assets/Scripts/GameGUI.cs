using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour 
{
    public GameObject winScreen;
    public Text scoreText;

    public void Start()
    {
        winScreen.SetActive(false);
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void Update()
    {
        scoreText.text = "Collected: " + GameController.GetInstance().playerPickupGetter.GetPickupCount(PickupType.Goal);
    }
}
