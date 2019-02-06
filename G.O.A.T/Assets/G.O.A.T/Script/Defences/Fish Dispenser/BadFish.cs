using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFish : MonoBehaviour
{
    private void OnTriggerEnter(Collider enter)
    {
        if(enter.gameObject.tag == "Enemies")
        {
            Destroy(this.gameObject);
        }
    }
}
