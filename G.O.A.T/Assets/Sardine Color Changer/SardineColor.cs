using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SardineColor : MonoBehaviour {
       
    // ATTACH TO SARDINE PREFABS

    SardineStats ss;

    public MeshRenderer rend;

    // Colours  
    public Color originalColorGreen = Color.green;
    public Color originalColorOrange = new Color(1f, 0.65f, 0f);
    public Color originalColorRed = Color.red;
        
    // Use this for initialization
    void Start ()
    {
        ss = FindObjectOfType<SardineStats>();       
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(ss.sardineHP);

        if (ss.sardineHP <= 0)
        {
            SceneManager.LoadScene("GameOver Screen");
        }

        else if (ss.sardineHP <= 2)    // Red
        {
            rend.material.color = Color.Lerp(rend.material.color, originalColorRed, Time.deltaTime);                      
        }

        else if (ss.sardineHP <= 5)    // Orange
        {
            rend.material.color = Color.Lerp(rend.material.color, originalColorOrange, Time.deltaTime);            
        }

        else if (ss.sardineHP <= 10)    // Green
        {
            rend.material.color = originalColorGreen;
        }    
    }
    /*
    void OnTriggerEnter(Collider other)
    {    
        if (other.gameObject.tag == "Enemies")
        { 
            ss.sardineHP -= ss.damageToTake;         
        }
    }*/
}
