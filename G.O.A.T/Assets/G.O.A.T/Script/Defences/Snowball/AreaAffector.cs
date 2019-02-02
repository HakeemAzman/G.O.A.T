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

    private void OnTriggerStay(Collider stay)
    {
        if (stay.gameObject.tag == "Enemies")
        {
            tsScript.enabled = true;
        }
    }
}
