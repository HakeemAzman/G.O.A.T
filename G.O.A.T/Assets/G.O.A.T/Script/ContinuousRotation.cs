using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotation : MonoBehaviour {

    float rotAmt = 7f;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, 0, -rotAmt * Time.deltaTime);
	}
}
