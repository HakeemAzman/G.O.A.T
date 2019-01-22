using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public float waterToDeduct;

    // for references
    CollectingWater theWater;

	// Use this for initialization
	void Start ()
    {
        theWater = FindObjectOfType<CollectingWater>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && theWater.percentageOfWater >= waterToDeduct)
        {
            theWater.WaterToLose(waterToDeduct);
            gameObject.SetActive(false);
        }
    }
}
