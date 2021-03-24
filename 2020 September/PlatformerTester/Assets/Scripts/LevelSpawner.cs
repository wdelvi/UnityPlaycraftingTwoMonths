using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public int numChunksToSpawn = 3;
    public float startingSpawnPosition = 3f;
    public List<GameObject> possibleLevelChunks;
    public List<GameObject> possibleSpawnedObjects;

    private float currentSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnPosition = startingSpawnPosition;

        SpawnLevelChunks();
    }

    // Update is called once per frame
    private void SpawnLevelChunks()
    {
        for (int i = 0; i < numChunksToSpawn; i++)
        {
            int levelChunkIndex = Random.Range(0, possibleLevelChunks.Count);
            GameObject levelChunk = possibleLevelChunks[levelChunkIndex];

            SpawnSingleChunk(levelChunk);
        }
    }

    private void SpawnSingleChunk(GameObject levelChunk)
    {
        GameObject spawnedChunk = Instantiate(levelChunk) as GameObject;

        spawnedChunk.transform.SetParent(this.transform);
        spawnedChunk.transform.position = new Vector3(currentSpawnPosition, 0f, 0f);

        LevelChunkController spawnedLevelChunkController = spawnedChunk.GetComponent<LevelChunkController>();

        currentSpawnPosition += spawnedLevelChunkController.GetLevelWidth();

        spawnedLevelChunkController.Setup(possibleSpawnedObjects);
    }
}
