using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PrefabSpawner prefabSpawner;
    public GameObject restartGamePanel;

    public void Update()
    {
        if (prefabSpawner == null)
        {
            return;
        }

        if(prefabSpawner.GetNumSpanwed() >= prefabSpawner.maximumPrefabsToSpawn )
        {
            //This is a pull relationship (vs a push one)
            //It pulls information from the prefab spawner
            ShowRestartGamePanel();
        }
    }

    public void Start()
    {
        HideRestartGamePanel();
    }

    public void ShowRestartGamePanel()
    {
        restartGamePanel.SetActive(true);
    }

    public void HideRestartGamePanel()
    {
        restartGamePanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
