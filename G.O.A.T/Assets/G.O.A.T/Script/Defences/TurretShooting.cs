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
        InvokeRepeating("ClosestEnemy", 0f, 1f);
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

    void ClosestEnemy()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag(whatToShoot);
        float shortestDistance = 5;
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

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0, 90, 0));
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
        audio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemies")
            Destroy(bullet, 1f);
    }

}