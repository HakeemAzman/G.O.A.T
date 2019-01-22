using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

   // To change how much of the perspective view can be viewed up and down change: y_angle_min and y_angle_max.
   // To change Sensitivity of the camera change: Left and Right - sensitivityX, Up and Down - sensitivityY.
   // To change distance of the camera facing the player, change distance.

    private const float y_angle_min = 0.0f;  
    private const float y_angle_max = 50.0f; 

    public Transform lookAt; // Direction to look at
    private Transform camTransform;

    private Camera cam;

    public Transform player;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

	// Use this for initialization
	void Start ()
    {
        camTransform = transform;
        cam = Camera.main;
	}

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, y_angle_min, y_angle_max); // Restricts camera within a certain set angle

        player.Rotate(0, currentX, 0);


        if (cam.transform.eulerAngles.x + (-currentY) > 80 && cam.transform.eulerAngles.x + (-currentY) < 280)
        { }
        else
        {
            cam.transform.RotateAround(player.position, cam.transform.right, -currentY);
        }
    }

    void LateUpdate ()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;

        // Focus on the player
        camTransform.LookAt(lookAt.position);
	}
}
