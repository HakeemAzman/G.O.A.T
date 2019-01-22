using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour {

    float turningSpeed;
    
    [Header("Left and Right Settings")]
    public bool canTurn = true;



    // Use this for initialization
    void Start () {

        turningSpeed = 10f;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A) && canTurn == true)
            transform.Rotate(0, turningSpeed * Time.deltaTime, 0, Space.World);

        if (Input.GetKey(KeyCode.D) && canTurn == true)
            transform.Rotate(0, -turningSpeed * Time.deltaTime, 0, Space.World);

    }
}
