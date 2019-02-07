using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialUpgrade : MonoBehaviour {

    public Button upgradeButton;
    public bool isUpgraded = false;
    public Animator anim;
    public GameObject newSpawner;
    public GameObject oldSpawner;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void upgrade1()
    {
        anim.SetBool("isUpgrade1", true);
        oldSpawner.SetActive(false);
        newSpawner.SetActive(true);
        isUpgraded = true;
    }
}
