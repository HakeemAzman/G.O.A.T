using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFish : MonoBehaviour
{
    public float destroyTimer;
    public Poison poiScript;

    private void Start()
    {
        destroyTimer = poiScript.poisonTimer;
    }

    private void OnTriggerEnter(Collider enter)
    {
        if(enter.gameObject.tag == "Enemies")
        {
            Destroy(this.gameObject, destroyTimer);
        }
    }
}
