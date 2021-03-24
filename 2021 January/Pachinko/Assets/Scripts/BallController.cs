using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float destroyAt;
    public PrefabSpawner prefabSpawner;

    public void Start()
    {
        Invoke("Die", 10f);
    }

    void Update()
    {
        if( transform.position.y < destroyAt )
        {
            Die();
        }
    }

    public void Die()
    {
        prefabSpawner.numDestroyed++;
        Destroy(gameObject);
    }
}
