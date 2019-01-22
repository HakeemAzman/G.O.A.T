using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public float Timer;
    public Animator anim;

    public bool firstWave;
    public bool secondWave;
    public bool thirdWave;
    

	// Use this for initialization
	void Start () {

        firstWave = true;
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("EnemyAI").Length == 0)
        {
            firstWave = false;
            if (!firstWave)
            {

            }
        }
	}
}
