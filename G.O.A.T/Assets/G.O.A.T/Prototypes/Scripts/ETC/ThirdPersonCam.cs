using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public bool cursorLocked = false;

    const float yAngleMin = 0;
    const float yAngleMax = 45f;

    public Transform character;

    float distanceFromplayer = -5f;
    public float currentX;
    public float currentY;

    private void Start()
    {
        if (cursorLocked == false)
        {
            Cursor.visible = false;
        }
    }

    void Update()
    {
        if (Input.GetAxis("Mouse X") != null || Input.GetAxis("Mouse Y") != null)
        {
            currentX += Input.GetAxis("Mouse X");
            currentY += Input.GetAxis("Mouse Y");
        }

        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);//Lock Y axis
    }

    void LateUpdate()
    {
        transform.position = character.position + Quaternion.Euler(currentY, currentX, 0) * new Vector3(0, 0, distanceFromplayer);
        transform.LookAt(character.position);
    }
}
