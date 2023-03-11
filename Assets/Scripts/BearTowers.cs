using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTowers : MonoBehaviour
{
    [Header("Attributes")]
    public Transform BearTowerPrefab;
    public float shootingRange = 15;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float rateOfFire = 2f;
    public string BeeTag = "Bee";

    [Header("Unity Setup Fields")]
    private float timer;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // This Checks for Target every certain seconds. In this case 0.5f secs.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        
        if(target == null) // If we don't have a target, then we don't want to do anything. We basically leave the fixed update alone
        {
            return;
        }
    }

    void UpdateTarget()
    {
        // We want to loop through all different enemy, but we need to store the enemies in an array.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(BeeTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) // If our distanceToEnemy is less than Shortest Distance than we now found an enemy closer than any we have found previously.
            {
                shortestDistance = distanceToEnemy;     // Then we set the shortDistance equal to the distanceToEnemy
                nearestEnemy = enemy;                   // Then we set the NearestEnemy = enemy
            }
        }

        if( nearestEnemy != null && shortestDistance <= shootingRange)
        {
            target = nearestEnemy.transform;
            Shoot();
        }
        else
        {
            target = null;
        }
    }


    void Shoot()
    {
        // Shooting Logic
        // To spawn object we use instantiate, the prefab, the position of spawn, then the rotation.

        if (timer >= rateOfFire)
        {
            GameObject BlueBerryGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // Casting this into an GameObject
            BlueBerry blueBerry = BlueBerryGO.GetComponent<BlueBerry>();    // This will find the component of this object
            timer = 0;

            if( blueBerry != null)
            {
                blueBerry.Seek(target);
            }
        }
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(BearTowerPrefab.position, shootingRange);
    }
}
