using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAffector : MonoBehaviour {
    public bool isTriggered = false;
    public bool startShooting = false;


    private void OnTriggerEnter(Collider enter)
    {
        if(enter.gameObject.tag == "Enemies")
        {
            startShooting = true;
        }
    }

    private void OnTriggerStay(Collider stay)
    {
        if (stay.gameObject.tag == "Enemies")
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider exit)
    {
        if (exit.gameObject.tag == "Enemies")
        {
            print("startShooting false");
            print(exit.name);
            startShooting = false;
            isTriggered = false;
        }
    }
}
