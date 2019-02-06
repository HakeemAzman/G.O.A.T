using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{

    public GameObject finalBoss;
    public Transform finalBossPos;
    public bool isSpawned = false;
    // Use this for initialization


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        finalBoss.SetActive(true);
    }
}
