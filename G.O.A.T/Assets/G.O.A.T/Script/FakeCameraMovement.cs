using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCameraMovement : MonoBehaviour {

    float turningSpeed;
    float movingSpeed;
    float sensitivity = 20;

    [Header("Left and Right Settings")]
    public bool canTurn = true;

    [Header("Floor and Ceil")]
    public float ceil = 8f;
    public float floor = 1f;

    [Header("Zooming In and Out")]
    public float minSize = 30;
    public float maxSize = 60;

	// Use this for initialization
	void Start ()
    {
        turningSpeed = 100f;
        movingSpeed = 10f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetKey(KeyCode.A) && canTurn == true)
        //    transform.Rotate(0, turningSpeed * Time.deltaTime, 0, Space.World);

        //if (Input.GetKey(KeyCode.D) && canTurn == true)
        //    transform.Rotate(0, -turningSpeed * Time.deltaTime, 0, Space.World);

        if (transform.position.y <= ceil)
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
        }

        if (transform.position.y >= floor)
        {
            if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector3.down * movingSpeed * Time.deltaTime);
        }

        float fov = Camera.main.orthographicSize;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minSize, maxSize);
        Camera.main.orthographicSize = fov;
    }
}
