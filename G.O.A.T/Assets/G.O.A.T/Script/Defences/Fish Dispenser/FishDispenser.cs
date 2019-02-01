using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDispenser : MonoBehaviour
{
    #region Feesh
    [Header ("Fish Dispenser Setup")]
    public Transform spawnHere;
    public GameObject prefabBadFish;
    private GameObject badFish;

    [Header ("Fish Dispenser Settings")]
    public float rateOfSpawn;

    private float spawnTimer;

    private void Start()
    {
        spawnTimer = rateOfSpawn;
    }

    private void Update()
    {
        if (badFish == null)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                spawnTimer = rateOfSpawn;
                badFish = Instantiate(prefabBadFish, spawnHere.position, spawnHere.rotation);
            }
        }
    }
    #endregion
}
