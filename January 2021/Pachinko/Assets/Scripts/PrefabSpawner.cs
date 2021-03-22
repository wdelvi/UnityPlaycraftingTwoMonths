using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int maxPrefabsToSpawn;
    public Text numSpawnedText;
    public string numSpawnedPrefix;

    public int numDestroyed = 0;

    private int numSpawned = 0;

    public void Start()
    {
        UpdateSpawnedText();
    }

    public void SpawnPrefab()
    {
        if (numSpawned >= maxPrefabsToSpawn && maxPrefabsToSpawn != 0)
        {
            return;
        }

        GameObject spawnedObject = Instantiate(prefabToSpawn) as GameObject;

        BallController spawnedBallController = spawnedObject.GetComponent<BallController>();

        if( spawnedBallController != null )
        {
            spawnedBallController.prefabSpawner = this;
        }

        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        spawnPosition.z = prefabToSpawn.transform.position.z;

        spawnedObject.transform.position = spawnPosition;

        numSpawned++;

        UpdateSpawnedText();
    }

    private void UpdateSpawnedText()
    {
        if (numSpawnedText != null)
        {
            numSpawnedText.text = numSpawnedPrefix + (maxPrefabsToSpawn - numSpawned);
        }
    }

    public int GetNumSpawned()
    {
        return numSpawned;
    }
}
