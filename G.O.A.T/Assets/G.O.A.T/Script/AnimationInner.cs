using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInner : MonoBehaviour {

    public float Timer;
    public Animator anim;

    public bool firstWave;
    public bool secondWave;
    public bool thirdWave;

    public GameObject Enemy2;

    // Use this for initialization
    void Start()
    {

        firstWave = true;
        anim = GetComponent<Animator>();
        gameObject.GetComponent<Animator>().SetBool("Wave1",false);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("EnemyAI").Length == 0)
        {
            firstWave = false;
            if (!firstWave)
            {
                gameObject.GetComponent<Animator>().SetBool("Wave1", true);
                secondWave = true;
            }
            if(secondWave)
            {
                
            }
        }
    }
}
