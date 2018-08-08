using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
    public float maxSeeDistance = 30f; 
    public float fireRate = 2f;
    public float bulletSpeed = 20f;
    public Transform target;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private float fireTimer; 

	// Use this for initialization
	void OnDrawGizmos () 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxSeeDistance);
	}
	
	// Update is called once per frame
    public void Update () 
    {
        if (target && bulletPrefab && bulletSpawnPoint)
        {
            if (IsWithinDistance(maxSeeDistance))
            {
                fireTimer += Time.deltaTime;

                if (fireTimer >= fireRate)
                {
                    Fire();
                }
            }
        }
	}

    private void Fire()
    {
        fireTimer = 0f;

        GameObject bullet = Instantiate( bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as GameObject;

        Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
    }

    private Vector3 GetDirection()
    {
        return target.position - transform.position;
    }

    private bool IsWithinDistance(float distance)
    {
        return (GetDirection().magnitude < distance);
    }
}
