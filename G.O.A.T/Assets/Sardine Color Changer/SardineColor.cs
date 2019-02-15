using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SardineColor : MonoBehaviour {
       
    // ATTACH TO SARDINE PREFABS

    SardineStats ss;
    public GameObject gameOver;
    public GameObject[] fishes;
        
    // Use this for initialization
    void Start ()
    {
        ss = FindObjectOfType<SardineStats>();       
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(ss.sardineHP);

        if (ss.sardineHP == 9)
        {
            fishes[0].gameObject.SetActive(false);
        }

        if (ss.sardineHP == 8)
        {
            fishes[1].gameObject.SetActive(false);
        }

        if (ss.sardineHP == 7)
        {
            fishes[2].gameObject.SetActive(false);
        }

        if (ss.sardineHP == 6)
        {
            fishes[3].gameObject.SetActive(false);
        }

        if (ss.sardineHP == 5)
        {
            fishes[4].gameObject.SetActive(false);
        }

        if (ss.sardineHP == 4)
        {
            fishes[5].gameObject.SetActive(false);
        }

        if (ss.sardineHP == 3)
        {
            fishes[6].gameObject.SetActive(false);
        }

        if (ss.sardineHP == 2)
        {
            fishes[7].gameObject.SetActive(false);
        }

        if (ss.sardineHP == 1)
        {
            fishes[8].gameObject.SetActive(false);
        }

        if (ss.sardineHP <= 0)
        {
            gameOver.gameObject.SetActive(true);
        }
    }
 
}
