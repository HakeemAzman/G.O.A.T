using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDispenser : MonoBehaviour
{
    #region Feesh
    [Header ("Fish Dispenser Setup")]
    public Transform spawnHere;
    public GameObject spawnHereBox;
    public GameObject prefabBadFish;
    private GameObject badFish;
    public AudioSource audio;
    [Header ("Fish Dispenser Settings")]
    public float rateOfSpawn;

    private float spawnTimer;
    private float spawnHereTimer = 10f;

    private void Start()
    {
        spawnTimer = rateOfSpawn;
    }

    private void Update()
    {
        spawnHereTimer -= Time.deltaTime;

        if (spawnHereTimer <= 0)
        {
            spawnHereBox.GetComponent<MeshRenderer>().enabled = false;
        }

        if (badFish == null)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                
                spawnTimer = rateOfSpawn;
                badFish = Instantiate(prefabBadFish, spawnHere.position, spawnHere.rotation);
                audio.Play();
            }
        }
    }
    #endregion
}
