using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
    public float maxSeeDistance = 30f;

    [Tooltip("How many seconds in between every shot")]
    [Range(0f,10f)]
    public float fireRate = 2f;
    public float bulletSpeed = 20f;
    public Transform target;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private float fireTimer;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, maxSeeDistance );
    }

    public void Update()
    {
        if( target && bulletPrefab && bulletSpawnPoint )
        {
            if( IsWithinDistance( maxSeeDistance ) )
            {
                fireTimer += Time.deltaTime;

                if( fireTimer >= fireRate )
                {
                    Fire();
                }
            }
        }
    }

    private void Fire()
    {
        fireTimer = 0f;

        GameObject bullet = Instantiate( bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation ) as GameObject;

        Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();

        bulletBody.velocity = bullet.transform.forward * bulletSpeed;
    }

    private Vector3 GetDirection()
    {
        return target.position - transform.position;
    }

    private bool IsWithinDistance( float distance )
    {
        return ( GetDirection().magnitude < distance );
    }
}
