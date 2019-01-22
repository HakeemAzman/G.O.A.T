using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct WaveSystem
    {
        public List<GameObject> WaveToSpawn;
    }

    [Header("Prefabs")]
    public GameObject PenguinPrefab;
    public GameObject WalrusPrefab;

    [Header("Float Value")]
    public float spawnDelay;
    public float waveTimer;
    public float valuetoAdd = 1;

    [Header("List")]
    public int waveNumber;
    public List<GameObject> waveToSpawn;
    public WaveSystem[] amountOfWaves;

    [Header("CoroutineSettings")]
    public float waitforSeconds;
    bool timerStart;
    public Text timerText;
    TowerUpgrade tuScript;
    public GameObject UpgradeHolder;

    void Start()
    {
        waveNumber = 1;
        waveToSpawn = amountOfWaves[waveNumber - 1].WaveToSpawn;
        
        InvokeRepeating("SpawnEnemy", 1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(waveTimer);
        //if(timerStart)
        //{
        //    waveTimer -= 1 * Time.deltaTime;
        //    timerText.text = "Chance to upgrade! \n" + waveTimer.ToString("f0");
        //    if (waveTimer <= 0)
        //    {
        //        waveTimer = 30;
        //        timerText.text = "";
        //    }
        //}

        if (waveToSpawn.Count == 0)
        {
            if (waveNumber < amountOfWaves.Length)
            {
                    StartCoroutine(NextWave());
                    waveToSpawn = amountOfWaves[waveNumber].WaveToSpawn;
                    waveNumber++;
            }
        }
        //if (waveNumber == 2 || waveNumber == 5 || waveNumber == 8)
        //{
            
        //    waitforSeconds = 30;
            
        //}
        //if (waveNumber == 3|| waveNumber == 6 || waveNumber == 9)
        //{
        //    UpgradeHolder.SetActive(true);
        //    waitforSeconds = 10;
        //    //StartCoroutine(TimeToWait());
        //}

    }

    void SpawnEnemy()
    {
        Instantiate(waveToSpawn[0], transform.position, transform.rotation);
        waveToSpawn.RemoveAt(0);
    }

    IEnumerator NextWave()
    {
        CancelInvoke("SpawnEnemy");
        yield return new WaitForSeconds(waitforSeconds);
        InvokeRepeating("SpawnEnemy", 1, 4);
    }

    IEnumerator TimeToWait()
    {
        timerStart = true;
        yield return new WaitForSeconds(30);
        UpgradeHolder.SetActive(false);
        timerStart = false;
    }
}
