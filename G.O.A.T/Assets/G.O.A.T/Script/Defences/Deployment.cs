using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deployment : MonoBehaviour
{
    [Header("Defences")]
    public GameObject turret;
    public GameObject poisonFish;

    [Header("Snowball Upgrade")]
    public GameObject snowballUpgrade;

    AudioSource audio;
    Selecting selectScript;

    CurrencySystem cs;

	// Use this for initialization
	void Start ()
    {
        cs = FindObjectOfType<CurrencySystem>();
        audio = GetComponent<AudioSource>();
        selectScript = FindObjectOfType<Selecting>();
	}

    //Deploys a defence using the position of the select grid.
    public void DeployTower()
    {
        if(cs.bubblesCount >= 50)
        {
            cs.bubblesCount -= 50;
            GameObject child = Instantiate(turret, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1.5f, selectScript.placementPos.z), Quaternion.identity);
            child.name = "Snowball Turret";
            audio.Play();
            selectScript.deploymentPanel.SetActive(false);
            Destroy(selectScript.currentlySelected);
        }
    }

    //Deploys a defence using the position of the select grid.
    public void DeployFishDispenser()
    {
        if (cs.bubblesCount >= 80)
        {
            cs.bubblesCount -= 80;
            GameObject child = Instantiate(poisonFish, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1.5f, selectScript.placementPos.z), Quaternion.identity);
            child.name = "Poison Fish Dispenser";
            audio.Play();
            selectScript.deploymentPanel.SetActive(false);
            Destroy(selectScript.currentlySelected);
        }
    }

    //Deploys an upgraded snowball
    public void SnowballUpgrade()
    {
        if (cs.bubblesCount >= 120)
        {
            cs.bubblesCount -= 120;
            GameObject child = Instantiate(snowballUpgrade, new Vector3(selectScript.turretPos.x, selectScript.turretPos.y, selectScript.turretPos.z), Quaternion.identity);
            child.name = "Snowball Turret - Level 2";
            audio.Play();
            selectScript.upgradePanel.SetActive(false);
            Destroy(selectScript.currentlySelected);
        }
    }

    public void CameraAndPanel()
    {
        selectScript.fcm.enabled = true;
    }
}
