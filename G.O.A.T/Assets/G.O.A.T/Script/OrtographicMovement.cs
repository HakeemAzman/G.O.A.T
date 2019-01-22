using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrtographicMovement : MonoBehaviour {

    float turningSpeed;
    public float movingSpeed;
    float sensitivity = 20;

    [Header("Floor and Ceil")]
    public float rotationMin = 0f;
    public float rotationMax = 50f;

    [Header("Fake Camera Script")]
    public FakeCameraMovement fcmScript;

    // Use this for initialization
    void Start ()
    {
        turningSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.A))
        {
            fcmScript.canTurn = false;
            transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.D))
        {
            fcmScript.canTurn = false;
            transform.Translate(Vector3.right * movingSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.W))
        {
            fcmScript.canTurn = false;
            transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.S))
        {
            fcmScript.canTurn = false;
            transform.Translate(Vector3.down * movingSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButtonUp(1))
            fcmScript.canTurn = true;

        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(turningSpeed * Time.deltaTime, 0, 0, Space.Self);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(-turningSpeed * Time.deltaTime, 0, 0, Space.Self);
    }
}
