using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour {
    bool aIsPressed = false;
    bool dIsPressed = false;
    bool tutorial1 = true;
    public GameObject tutorialBox;
    public Text tutorialText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
        {
            aIsPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            dIsPressed = true;
        }

        if(aIsPressed && dIsPressed)
        {
            tutorialBox.SetActive(false);
            tutorial1 = false;
        }

        if (!tutorial1)
        {
            tutorialText.text = ("Click on the ribbon to see your currency and life");
            tutorialBox.SetActive(true);
        }

    }

}
