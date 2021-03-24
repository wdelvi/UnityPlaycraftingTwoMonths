using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChunkController : MonoBehaviour
{
    [Range(0f, 1f)]
    public float spawnLiklihood = 0.5f;

    public SpriteRenderer chunkSize;
    public List<Transform> spawnPositions;

    // Start is called before the first frame update
    public void Setup( List<GameObject> possibleSpawnedObjects )
    {
        foreach(Transform spawnPosition in spawnPositions)
        {
            if( Random.Range(0f,1f) < spawnLiklihood)
            {
                int prefabToSpawnIndex = Random.Range(0, possibleSpawnedObjects.Count);
                GameObject prefabToSpawn = possibleSpawnedObjects[prefabToSpawnIndex];

                SpawnObject(prefabToSpawn, spawnPosition);
            }
        }
    }

    public float GetLevelWidth()
    {
        return chunkSize.bounds.size.x;
    }

    private void SpawnObject( GameObject prefabToSpawn, Transform spawnPosition )
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn) as GameObject;

        spawnedObject.transform.SetParent(this.transform);
        spawnedObject.transform.position = spawnPosition.position;
    }
}
