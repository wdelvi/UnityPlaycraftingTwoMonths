using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public int numberOfChunks = 3;
    public float startingSpawnPosition = 10f;
    public List<GameObject> possibleChunkPrefabs;
    public List<GameObject> possibleObjectPrefabs;

    private float currentSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnPosition = startingSpawnPosition;

        SpawnLevel();
    }

    private void SpawnLevel()
    {
        //Create X number of chunks
        for(int i = 0; i < numberOfChunks; i++)
        {
            //Choose what chunk to spawn
            int chunkIndex = Random.Range(0, possibleChunkPrefabs.Count);
            GameObject chunkToSpawn = possibleChunkPrefabs[chunkIndex];

            //Spawn the chunk
            SpawnChunk(chunkToSpawn);
        }
    }

    private void SpawnChunk( GameObject chunkToSpawn )
    {
        //spawn the chunk
        GameObject spawnedChunk = Instantiate(chunkToSpawn) as GameObject;

        //Set the parent
        spawnedChunk.transform.SetParent(this.transform);

        //set the position
        spawnedChunk.transform.position = new Vector3(currentSpawnPosition, 0f, 0f);

        LevelChunkController spawnedLevelChunkController = spawnedChunk.GetComponent<LevelChunkController>();

        currentSpawnPosition += spawnedLevelChunkController.GetChunkWidth();

        //Tell the chunk to spawn stuff itself
        spawnedLevelChunkController.Setup(possibleObjectPrefabs);
    }
}
