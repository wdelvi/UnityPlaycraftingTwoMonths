using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int maximumPrefabsToSpawn;
    public Text numSpawnedText;
    public string numSpawnedPrefix;

    private int numSpawned = 0;

    public void Start()
    {
        if (numSpawnedText != null)
        {
            numSpawnedText.text = numSpawnedPrefix + (maximumPrefabsToSpawn - numSpawned);
        }
    }

    public void Spawn()
    {
        if( numSpawned >= maximumPrefabsToSpawn )
        {
            return;
        }

        GameObject spawnedObject = Instantiate(prefabToSpawn) as GameObject;

        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        spawnPosition.z = 0;

        spawnedObject.transform.position = spawnPosition;

        numSpawned++;

        if( numSpawnedText != null )
        {
            numSpawnedText.text = numSpawnedPrefix + (maximumPrefabsToSpawn - numSpawned);
        }
    }

    public int GetNumSpanwed()
    {
        return numSpawned;
    }

    public void SetNumSpawned( int numToSet )
    {
        numSpawned = numToSet;
    }
}
