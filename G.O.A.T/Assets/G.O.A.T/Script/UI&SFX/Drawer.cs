using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour {

    Animator drawerAnim;
    public bool canOpen = false;

	// Use this for initialization
	void Start ()
    {
        //drawerAnim.SetBool("isOpen", false);
        drawerAnim = gameObject.GetComponent<Animator>();	
	}

    public void drawer()
    {
        if(canOpen == false)
        {
            drawerAnim.SetBool("isOpen", true);
            canOpen = true;
        }
        else
        {
            drawerAnim.SetBool("isOpen", false);
            canOpen = false;
        }
    }
}
