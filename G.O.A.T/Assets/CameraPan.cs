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
        //if (i == 0)
        //{
        //    CameraObject[0].SetActive(true);
        //}
        //if (Input.GetKeyDown("a"))
        //{
        //    i -= 1;
        //    if (i <= 0)
        //    {

        //    }
        //    if (Input.GetKeyDown("a") && i == 1)
        //    {
        //        CameraObject[0].SetActive(false);
        //        CameraObject[1].SetActive(true);
        //    }
        //    if (Input.GetKeyDown("a") && i == 2)
        //    {
        //        CameraObject[2].SetActive(false);
        //        CameraObject[1].SetActive(true);
        //    }
        //    if (Input.GetKeyDown("a") && i == 3)
        //    {
        //        CameraObject[3].SetActive(true);
        //        CameraObject[2].SetActive(false);
        //    }
        //    if (Input.GetKeyDown("a") && i == 4)
        //    {
        //        CameraObject[0].SetActive(true);

        //    }

        //}
        //if (Input.GetKeyDown("d"))
        //{
        //    i++;
        //    if (Input.GetKeyDown("d") && i == 1)
        //    {
        //        CameraObject[1].SetActive(true);
        //        CameraObject[0].SetActive(false);
        //    }
        //    if (Input.GetKeyDown("d") && i == 2)
        //    {
        //        CameraObject[2].SetActive(true);
        //        CameraObject[1].SetActive(false);
        //    }
        //    if (Input.GetKeyDown("d") && i == 3)
        //    {
        //        CameraObject[3].SetActive(true);
        //        CameraObject[2].SetActive(false);
        //    }
        //    if (Input.GetKeyDown("d") && i == 4)
        //    {
        //        CameraObject[3].SetActive(false);
        //        CameraObject[0].SetActive(true);
        //        i = 0;
        //    }
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
        if (Input.GetKeyDown("d"))
        {
            i++;
        }

        if(Input.GetKeyDown("a"))
        {
            i--;
        }

    }
}


