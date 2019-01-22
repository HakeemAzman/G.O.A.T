using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour {
    
    private Camera maincamera;
    public SpriteRenderer sr;
    private bool canFollow = false;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        maincamera = FindObjectOfType<Camera>();
        sr.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(canFollow)
        {
            
            Ray cameraRay = maincamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay,out rayLength))
            {
                Vector3 point = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, point, Color.red);
                transform.position = point;
            }

        }
       
    }
    
    public void touched()
    {
        sr.gameObject.SetActive(true);
        canFollow = true;
    }


}




