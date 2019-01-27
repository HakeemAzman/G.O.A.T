using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAffector : MonoBehaviour
{
    TurretShooting tsScript;

    private void Start()
    {
        tsScript = FindObjectOfType<TurretShooting>();
        tsScript.enabled = false;
    }

    private void OnTriggerEnter(Collider enter)
    {
        if(enter.gameObject.tag == "Enemies")
        {
            //Debug.Log("enter");
           // tsScript.enabled = true;
        }
    }

    private void OnTriggerStay(Collider stay)
    {
        if (stay.gameObject.tag == "Enemies")
        {
            tsScript.enabled = true;
        }
    }

    private void OnTriggerExit(Collider exit)
    {
        if (exit.gameObject.tag == "Enemies")
        {
            //tsScript.enabled = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}
