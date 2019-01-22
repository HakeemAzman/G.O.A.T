using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour {

    [Header ("UI Related")]
    public Text waterText;

    [Header ("Water Related")]
    public bool canCollectWater = false;

    void OnTriggerEnter(Collider enter)
    {
        if (enter.gameObject.tag == "Player")
        {
            canCollectWater = true;
            waterText.text = "Press 'E' to collect water!";
        }
    }

    void OnTriggerExit (Collider exit)
    {
        if (exit.gameObject.tag == "Player")
        {
            canCollectWater = false;
            waterText.text = "";
        }
    }
}
