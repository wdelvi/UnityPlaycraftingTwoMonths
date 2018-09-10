using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawnerV1 : MonoBehaviour 
{
    public GameObject prefabToSpawn;

    public void SpawnPrefab()
    {
        GameObject spawnedPrefab = Instantiate(prefabToSpawn) as GameObject;
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.z = spawnedPrefab.transform.position.z;
        spawnedPrefab.transform.position = spawnPosition;
    }
}
