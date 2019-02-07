using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deployment : MonoBehaviour
{
    [Header("Defences")]
    public GameObject turret;
    public GameObject poisonFish;
    public GameObject blastFurnace;
    public GameObject buildingBlock;

    [Header("Snowball Upgrade")]
    public GameObject snowballUpgrade;
    public GameObject PistonGO;
    public GameObject buildvfx;
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

    #region All Deployments/Remove
    //Deploys a defence using the position of the select grid.
    public void DeployTower()
    {
        if(cs.bubblesCount >= 50)
        {
            cs.bubblesCount -= 50;
            Instantiate(buildvfx, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1.75f, selectScript.placementPos.z), Quaternion.identity);
            GameObject child = Instantiate(turret, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1.75f, selectScript.placementPos.z), Quaternion.identity);
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
            GameObject child = Instantiate(poisonFish, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1f, selectScript.placementPos.z), Quaternion.identity);
            child.name = "Poison Fish Dispenser";
            Instantiate(buildvfx, transform.position, Quaternion.identity);
            audio.Play();
            selectScript.deploymentPanel.SetActive(false);
            Destroy(selectScript.currentlySelected);
        }
    }

    //Depoys a piston using the position of the select grid
    public void Piston()
    {
        if (cs.bubblesCount >= 100)
        {
            cs.bubblesCount -= 100;
            GameObject child = Instantiate(blastFurnace, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1f, selectScript.placementPos.z), Quaternion.identity);
            child.name = "Blast Furnace";
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
            Instantiate(buildvfx, transform.position, Quaternion.identity);
            GameObject child = Instantiate(snowballUpgrade, new Vector3(selectScript.turretPos.x, selectScript.turretPos.y, selectScript.turretPos.z), Quaternion.identity);
            child.name = "Snowball Turret - Level 2";
            audio.Play();
            selectScript.upgradeSnowballPanel.SetActive(false);
            Destroy(selectScript.currentlySelected);
        }
    }

    public void RemoveSnowball()
    {
        selectScript.hasDeleted = true;

        cs.bubblesCount += 50;
        GameObject block = Instantiate(buildingBlock, new Vector3(selectScript.turretPos.x, selectScript.turretPos.y - 1.8f, selectScript.turretPos.z), Quaternion.identity);
        block.name = "Build here!";
        Destroy(selectScript.currentlySelected);
        selectScript.upgradeSnowballPanel.SetActive(false);
    }

    public void RemoveFishDispenser()
    {
        selectScript.hasDeleted = true;

        cs.bubblesCount += 80;
        GameObject block = Instantiate(buildingBlock, new Vector3(selectScript.turretPos.x, selectScript.turretPos.y - 1f, selectScript.turretPos.z), Quaternion.identity);
        block.name = "Build here!";
        Destroy(selectScript.currentlySelected);
        selectScript.upgradeFishDispencerPanel.SetActive(false);
    }

    public void RemovePiston()
    {
        selectScript.hasDeleted = true;

        cs.bubblesCount += 100;
        GameObject block = Instantiate(buildingBlock, new Vector3(selectScript.turretPos.x, selectScript.turretPos.y - 1f, selectScript.turretPos.z), Quaternion.identity);
        block.name = "Build here!";
        Destroy(selectScript.currentlySelected);
        selectScript.upgradePistonPanel.SetActive(false);
    }
    
    public void Rotation()
    {
        
        selectScript.currentlySelected.transform.Rotate(0, 90, 0);
    }
    #endregion

    public void CameraAndPanel()
    {
        selectScript.fcm.enabled = true;
    }
}
