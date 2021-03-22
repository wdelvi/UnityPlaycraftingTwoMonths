using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void SpawnPrefab()
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn) as GameObject;

        Vector3 spawnPosition =
            Camera.main.ScreenToWorldPoint( Input.mousePosition );

        spawnPosition.z = 0f;

        spawnedObject.transform.position = spawnPosition;

        audioSource.Play();
    }
}
