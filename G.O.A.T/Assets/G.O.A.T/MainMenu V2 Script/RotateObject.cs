using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    GameObject displayObject;
    float speed;

	// Use this for initialization
	void Start () {
        speed = 1f;
        displayObject = (GameObject)this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

         if (Input.GetKey(KeyCode.A))
             displayObject.transform.Rotate(0, speed, 0);

        if (Input.GetKey(KeyCode.D))
            displayObject.transform.Rotate(0, -speed, 0);

    }
}
