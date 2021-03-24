using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PrefabSpawner prefabSpawner;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(prefabSpawner == null)
        {
            return;
        }

        if( prefabSpawner.numDestroyed >= prefabSpawner.maxPrefabsToSpawn )
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level2");
    }
}
