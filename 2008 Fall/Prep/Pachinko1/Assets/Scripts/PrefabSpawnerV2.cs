using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawnerV2 : MonoBehaviour 
{
    public GameObject prefabToSpawn;
    public int maxSpawns;

    private int numSpawns;

    public void SpawnPrefab()
    {
        if ( CanSpawn() )
        {
            GameObject spawnedPrefab = Instantiate(prefabToSpawn) as GameObject;
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = spawnedPrefab.transform.position.z;
            spawnedPrefab.transform.position = spawnPosition;

            numSpawns ++;
        }
    }

    public int GetRemainingSpawns()
    {
        return maxSpawns - numSpawns;
    }

    public bool CanSpawn()
    {
        return (numSpawns < maxSpawns);
    }
}
