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
    bool tutorial4 = true;
    bool upgradebool = true;
    public GameObject tutorialBox;
    public Text tutorialText;
    public Drawer drawRibbon;
    public Selecting Sscript;
    public Deployment dpScript;
    public BtnManager btnScript;
    public TutorialUpgrade tscript;
    public Animator blinkingDrawer;
    public Animator blinkingDeploy;
    public Animator blinkingReady;
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
            blinkingDrawer.SetBool("tutorialOn", true);
            tutorialText.text = ("Click on the ribbon to see your currency and life. You can also click on it again to close it");
            tutorialBox.SetActive(true);
            
        }

        if(drawRibbon.canOpen == true)
        {
            blinkingDrawer.SetBool("tutorialOn", false);
            tutorialText.text = ("The bubbles are your currency for building defenses and the fishes are your lives.");
            tutorial2 = false;
        }

        if(!tutorial2)
        {
            blinkingDeploy.SetBool("isDeploy", true);
            tutorialText.text = ("Click on the icebergs to deploy a turret! They will cost you some bubbles!");
            if(Sscript.hasHit)
            {
                tutorialBox.SetActive(false);
            }
        }

        if (dpScript.hasDeploy == true)
        {
            blinkingDeploy.SetBool("isDeploy", false);
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
            blinkingReady.SetBool("isReady", true);
            tutorialText.text = ("Click on the Penguin button on the top left to begin the wave whenever you're done with deploying your defenses!");
            tutorialBox.SetActive(true);
            
        }
        if(btnScript.isReady == true)
        {
            tutorial4 = false;
            
        }

        if(!tutorial4)
        {
            tutorialBox.SetActive(false);
            StartCoroutine(timeToWait());
        }
        if(!upgradebool)
        {
            tutorialText.text = ("Click on Upgrade in the scroll to raise the tower! Once you rise up high enough, a Boss will spawn and once you kill it, you win!");
            tutorialBox.SetActive(true);
           
        }
        
        if(tscript.isUpgraded == true)
        {
            tutorialBox.SetActive(false);
        }
        
    }

    IEnumerator timeDelay()
    {
        yield return new WaitForSeconds(5f);
        tutorial3 = false;
    }

    IEnumerator timeToWait()
    {
        yield return new WaitForSeconds(30f);
        upgradebool = false;

    }
}
