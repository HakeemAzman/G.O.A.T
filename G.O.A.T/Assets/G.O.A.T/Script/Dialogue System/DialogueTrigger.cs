using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    DialogueManager dm;

    void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }

    void OnTriggerEnter(Collider other)
    {

      //  Debug.Log("Trigger");

        if (other.tag == "Player")
        {
            Debug.Log("StartCoroutine");
            StartCoroutine(dm.TextPopsUp());
        }
        
    }

}
