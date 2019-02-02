using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

    public GameObject[] CameraObject;
    public int i;
    
	// Use this for initialization
	void Start () {
        i = 0;
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log(i);

        if (Input.GetKeyDown("d"))
        {
            i++;
        }

        if (Input.GetKeyDown("a"))
        {
            i--;
        } 

        if (i == 0)
        {
            CameraObject[0].SetActive(true);
        }

        if (i == 1)
        {
            CameraObject[1].SetActive(true);
        }

        if (i == 2)
        {
            CameraObject[2].SetActive(true);
        }

        if (i == 3)
        {
            CameraObject[3].SetActive(true);
        }

        if (i != 0)
        {
            CameraObject[0].SetActive(false);
        }

        if (i != 1)
        {
            CameraObject[1].SetActive(false);
        }

        if(i != 2)
        {
            CameraObject[2].SetActive(false);
        }

        if(i != 3)
        {
            CameraObject[3].SetActive(false);
        }
        
        if(i == 4)
        {
            CameraObject[0].SetActive(true);
            i = 0;
        }

        if(i == -1)
        {
            i = 3;
            CameraObject[3].SetActive(true);
        }
       

    }
}


