using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFish : MonoBehaviour
{
    public float destroyTimer;
    public Poison poiScript;

    public bool hasTouched = false;

    private void Start()
    {
        destroyTimer = poiScript.poisonTimer;
    }

    private void OnTriggerEnter(Collider enter)
    {
        if(enter.gameObject.tag == "Enemies")
        {
            hasTouched = true;
            Destroy(this.gameObject, destroyTimer);
        }
    }
}
