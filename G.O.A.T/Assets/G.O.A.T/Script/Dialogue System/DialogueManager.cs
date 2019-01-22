using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour {


    //public TextMeshPro tmPro;
    //public TextMeshProUGUI Text;
    public GameObject Text1;
    Animator Anim;

	// Use this for initialization
	void Start () {
        // tmPro = GetComponent<TextMeshPro>();
        Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public IEnumerator TextPopsUp()
    {
        Text1.SetActive(true);

       // Debug.Log("Text Appears");

        yield return new WaitForSeconds(3f);

        Text1.SetActive(false);
           
    }

}
