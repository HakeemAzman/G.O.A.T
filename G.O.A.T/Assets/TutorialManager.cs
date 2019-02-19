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
    public endnemyStats eScript;
    public Animator blinkingDrawer;
    public Animator blinkingDeploy;
    public Animator blinkingReady;

    public Text[] instructions;
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
            tutorialText.text = ("The icons on the top right are important! The bubbles are your currency and the Fishes are your lives!");
            instructions[0].GetComponent<Text>().color = new Color(0, 0, 0, 150);
            StartCoroutine (delay());
            
        }


        //if(!tutorial1)
        //{
        //    tutorialBox.SetActive(true);
        //    tutorialText.text = ("The bubbles are your currency for building defenses and the fishes are your lives.");
        //    tutorial2 = false;
        //}

        if(!tutorial2)
        {
            blinkingDeploy.SetBool("isDeploy", true);
            tutorialText.text = ("Click on the blinking to deploy a turret! They will cost you some bubbles!");
            if(Sscript.hasHit)
            {
                tutorialBox.SetActive(false);
            }
        }

        if (dpScript.hasDeploy == true)
        {
            blinkingDeploy.SetBool("isDeploy", false);
            instructions[1].GetComponent<Text>().color = new Color(0, 0, 0, 150);
            tutorialText.text = ("You have now deployed a snowball turret! You may continue to deploy more until your defenses are ready!");
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
            instructions[2].GetComponent<Text>().color = new Color(0, 0, 0, 150);
            tutorial4 = false;
            
        }

        if(!tutorial4)
        {
            tutorialBox.SetActive(false);
            StartCoroutine(timeToWait());
        }
        if(!upgradebool)
        {

            tutorialText.text = ("Click on 'Lower' at the bottom right of the screen to lower the sea levels! Once you rise up high enough, a Boss will spawn and once you kill it, you win!");
            tutorialBox.SetActive(true);
           
        }
        
        if(tscript.isUpgraded == true)
        {
            instructions[3].GetComponent<Text>().color = new Color(0, 0, 0, 150);
            tutorialBox.SetActive(false);
        }

        if(eScript.isdead == true)
        {
            instructions[4].GetComponent<Text>().color = new Color(0, 0, 0, 150);
        }
        
        
    }
    
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3f);
        tutorial2 = false;
    }

    IEnumerator timeDelay()
    {
        yield return new WaitForSeconds(5f);
        tutorial3 = false;
    }

    IEnumerator deployDelay()
    {
        yield return new WaitForSeconds(3f);
        tutorialBox.SetActive(false);
        
    }

    IEnumerator timeToWait()
    {
        yield return new WaitForSeconds(30f);
        upgradebool = false;
    }
}
