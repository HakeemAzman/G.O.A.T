using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour {
    bool aIsPressed = false;
    bool dIsPressed = false;
    bool startButton = false;
    bool tutorial1 = true;
    bool tutorial2 = true;
    bool tutorial3 = true;
    public GameObject tutorialBox;
    public Text tutorialText;
    public Drawer drawRibbon;
    public Selecting Sscript;
    public Deployment dpScript;
    public BtnManager btnScript;
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
            tutorialText.text = ("Click on the ribbon to see your currency and life.");
            tutorialBox.SetActive(true);
        }

        if(drawRibbon.canOpen == true)
        {
            tutorialText.text = ("The bubbles are your currency for building defenses and the fishes are your lives.");
            tutorial2 = false;
        }

        if(!tutorial2)
        {
            tutorialText.text = ("Click on the icebergs to deploy a turret! They will cost you some bubbles!");
            if(Sscript.hasHit)
            {
                tutorialBox.SetActive(false);
            }
        }

        if (dpScript.hasDeploy == true)
        {
            tutorialText.text = ("You have now deployed a snowball turret! Now you can fend off those pesky penguins from your fishes!");
            tutorialBox.SetActive(true);
            StartCoroutine(timeDelay());
        }

        if(!tutorial3)
        {
            tutorialBox.SetActive(false);
            startButton = true;
        }

        if(startButton)
        {
            tutorialText.text = ("Click on the Penguin button on the top left to begin the wave!");
            tutorialBox.SetActive(true);  
        }

        if(btnScript.isReady)
        {
            tutorialBox.SetActive(false);
        }
    }

    IEnumerator timeDelay()
    {
        yield return new WaitForSeconds(5f);
        tutorial3 = false;
    }
}
