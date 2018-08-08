using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSpawner : MonoBehaviour 
{
    public Transform target;

    public int spawnNumOnStart;

    public float distanceRequiredToSpawn;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public List<GameObject> spawnPrefabs;

    private Vector3 lastSpawnPosition;
    private Vector3 baseSpawnPosition;

    private int spawnIndex = 0;

	public void Start () 
    {
        if ( target == null )
        {
            return;
        }

        baseSpawnPosition = transform.position;
        lastSpawnPosition = transform.position;
        lastSpawnPosition.x += Random.Range( xMin, xMax );

        for ( var i = 0; i < spawnNumOnStart; i++ )
        {
            Spawn();
        }
	}
	
	// Update is called once per frame
    public void Update () 
    {
        if ( target == null )
        {
            return;
        }

        Vector3 targetPosition = target.position;

        if ( Vector3.Distance( targetPosition, lastSpawnPosition ) <= distanceRequiredToSpawn )
        {
            Spawn();
        }
	}

    public void Spawn()
    {
        GameObject prefabToSpawn = spawnPrefabs[ Random.Range( 0, spawnPrefabs.Count ) ];

        GameObject spawnedObject = Instantiate( prefabToSpawn ) as GameObject;

        float spawnX = lastSpawnPosition.x + Random.Range( xMin, xMax );
        float spawnY = baseSpawnPosition.y + Random.Range( yMin, yMax );
        float spawnZ = prefabToSpawn.transform.position.z;

        spawnedObject.transform.position = new Vector3( spawnX, spawnY, spawnZ );

        lastSpawnPosition = spawnedObject.transform.position;
        lastSpawnPosition.x += spawnedObject.GetComponent<Collider2D>().bounds.size.x;
    }
}
