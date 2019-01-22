using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform cam;

    float speed = 10f;
    float turnSpeed = 10f;

    Rigidbody rb;

    Vector3 moveDirection;
    public float gravityScale;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
	}

    void FixedUpdate()
    {
        Vector3 dir = (cam.forward * Input.GetAxis("Vertical")) + (cam.right * Input.GetAxis("Horizontal"));

        dir.y = 0;

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
             rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime); //rotate from this to new rotation at turnSpeed
             rb.velocity = transform.forward * speed;
        }
    }
}
