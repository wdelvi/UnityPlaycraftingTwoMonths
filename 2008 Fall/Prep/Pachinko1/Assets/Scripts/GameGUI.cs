using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour 
{
    public PointCollector pointCollector;
    public PrefabSpawnerV2 prefabSpawner;
    public Text scoreText;
    public Text livesText;
    public GameObject restartButton;

    // Use this for initialization
    void Start () 
    {
        scoreText.text = "Score: 0";
        livesText.text = "Lives: 0";
    }
	
	// Update is called once per frame
	void Update () 
    {
        scoreText.text = "Score: " + pointCollector.GetPoints();
        livesText.text = "Lives: " + prefabSpawner.GetRemainingSpawns();

        if( prefabSpawner.CanSpawn() )
        {
            restartButton.SetActive(false);
        }
        else
        {
            restartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
