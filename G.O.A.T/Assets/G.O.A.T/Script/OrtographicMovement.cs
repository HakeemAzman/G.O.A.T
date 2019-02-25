using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrtographicMovement : MonoBehaviour {

    float turningSpeed;
    public float movingSpeed;
    public float followSpeed;
    float sensitivity = 20;
    public GameObject audioList;

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
            audioList.transform.position = gameObject.transform.position;
        }

        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.D))
        {
            fcmScript.canTurn = false;
            transform.Translate(Vector3.right * movingSpeed * Time.deltaTime);
            audioList.transform.position = gameObject.transform.position;
        }

        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.W))
        {
            fcmScript.canTurn = false;
            transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
            audioList.transform.position = gameObject.transform.position;
        }

        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.S))
        {
            fcmScript.canTurn = false;
            transform.Translate(Vector3.down * movingSpeed * Time.deltaTime);
            audioList.transform.position = gameObject.transform.position;
        }

        if (Input.GetMouseButtonUp(1))
            fcmScript.canTurn = true;

       /* if (Input.GetKey(KeyCode.Q))
            transform.Rotate(turningSpeed * Time.deltaTime, 0, 0, Space.Self);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(-turningSpeed * Time.deltaTime, 0, 0, Space.Self); */
    }
}
