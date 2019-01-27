using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    ShootStats ssScript;
    GameObject bullet;
    AudioSource audio;

    Transform target;
    EnemyAI enemyScript;

    AreaAffector aaScript;

    [Header("Range of fire")]
    public float range = 15f;

    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    float fireCountdown = 0f;

    [Header("Turret Setup")]
    public string whatToShoot = "Enemies";

    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePos;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        ssScript = GameObject.FindObjectOfType<ShootStats>();
       
        InvokeRepeating("ClosestEnemy", 0f, 0.5f);
    }

    void ClosestEnemy()
    {
        GameObject[] enemy;
        enemy = GameObject.FindGameObjectsWithTag(whatToShoot);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject e in enemy)
        {
            float distToEnemy = Vector3.Distance(transform.position, e.transform.position);

            if (distToEnemy < shortestDistance)
            {
                shortestDistance = distToEnemy;
                nearestEnemy = e;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            enemyScript = nearestEnemy.GetComponent<EnemyAI>();
        }
        else
            target = null;
    }

    private void Update()
    {
        LockOnTarget();

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate
            (
            bulletPrefab,
            firePos.position,
            firePos.rotation
            );
        Destroy(bullet, 1f);

        ShootStats ss = bullet.GetComponent<ShootStats>();

        if (ss != null)
        {
            ss.Seek(target);
        }
        
        audio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemies")
            Destroy(bullet, 1f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}