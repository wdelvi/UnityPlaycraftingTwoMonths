using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChunkController : MonoBehaviour
{
    [Range(0f,1f)]
    public float chanceToSpawnObject = 0.5f;
    public List<Transform> spawnPositions;
    public SpriteRenderer chunkSize;

    // Start is called before the first frame update
    public void Setup( List<GameObject> possibleSpawnedObjects )
    {
        //Run through every spawn position this chunk has
        foreach( Transform spawnPosition in spawnPositions )
        {
            //X% of the time, spawn SOMETHING
            if( Random.Range(0f,1f) < chanceToSpawnObject )
            {
                //Choose what to spawn
                int objectToSpawnIndex = Random.Range(0, possibleSpawnedObjects.Count);
                GameObject objectToSpawn = possibleSpawnedObjects[objectToSpawnIndex];

                //Spawn it
                SpawnObject(objectToSpawn, spawnPosition);
            }
        }
    }

    public float GetChunkWidth()
    {
        return chunkSize.bounds.size.x;
    }

    private void SpawnObject( GameObject prefabToSpawn, Transform spawnPosition )
    {
        //Create a new object
        GameObject spawnedObject = Instantiate(prefabToSpawn) as GameObject;

        //Set the parent to this object
        spawnedObject.transform.SetParent(this.transform);

        //Change it's position to be one of the spawn positions
        spawnedObject.transform.position = spawnPosition.position;
    }
}
