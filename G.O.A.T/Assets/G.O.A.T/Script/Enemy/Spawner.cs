    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Objects")]
    public GameObject pivot;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    GameObject currentEnemy;
    float respawnTimer;
    float delayTime = 1f;
    bool wave1;
    bool wave2;
    void Start()
    {
        respawnTimer = 0.0f;

        wave1 = true;

    }

    void Update()
    {
        respawnTimer += Time.deltaTime; // Start Timer

        if (wave1)
        {
            InvokeRepeating("SpawnWave1", 4f, 4f); //Repeats after delaying for 3 seconds per sec
        }
    }

    void SpawnWave1()
    {
        currentEnemy = (GameObject)Instantiate(enemyPrefab, transform.position, transform.rotation);
        currentEnemy.transform.SetParent(pivot.transform, true);
        currentEnemy.transform.rotation = pivot.transform.rotation;
    }

    void SpawnEnemies2()
    {
        currentEnemy = (GameObject)Instantiate(enemyPrefab2, transform.position, transform.rotation);
        currentEnemy.transform.SetParent(pivot.transform, true);
        currentEnemy.transform.rotation = pivot.transform.rotation;
    }

    void Ready()
    {
        wave2 = true;
    }
}
