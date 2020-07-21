using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
    public Transform target;

    public float maxSeeDistance = 30f;
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    public float bulletSpeed = 20f;
    public Transform bulletSpawnPoint;
    public Transform turret;

    private float fireTimer;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxSeeDistance);
    }
	
	void Update () 
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

                turret.LookAt(target);
            }
        }
	}

    private void Fire()
    {
        fireTimer = 0f;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation ) as GameObject;

        Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();

        bulletBody.velocity = bullet.transform.forward * bulletSpeed;
    }

    private Vector3 GetDirection()
    {
        return target.position - transform.position;
    }

    private bool IsWithinDistance( float distance )
    {
        return (GetDirection().magnitude < distance);
    }
}
