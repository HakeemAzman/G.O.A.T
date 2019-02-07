﻿using System.Collections;
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
    public GameObject fishDispenserUpgrade;
    public GameObject blastFurnaceUpgrade;
    public GameObject PistonGO;
    public GameObject buildvfx;

    [Header("Description Boxes")]
    public GameObject snowPanel;
    public GameObject fishPanel;
    public GameObject blastPanel;

    [Header("Snow Upgrade Boxes")]
    public GameObject snowUpgrade;
    public GameObject snowSell;

    [Header("Fish Upgrade Boxes")]
    public GameObject fishTurn;
    public GameObject fishUpgrade;
    public GameObject fishSell;

    [Header("Blast Furnace Boxes")]
    public GameObject blastfTurn;
    public GameObject blastfUpgrade;
    public GameObject blastfSell;

    CurrencySystem cs;
    AudioSource audio;
    [Header("SellSound")]
    public AudioSource sellAudio;
    Selecting selectScript;

    // Use this for initialization
    void Start ()
    {
        cs = FindObjectOfType<CurrencySystem>();
        audio = GetComponent<AudioSource>();
        selectScript = FindObjectOfType<Selecting>();
	}

    public void CameraAndPanel()
    {
        selectScript.fcm.enabled = true;
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
            Instantiate(buildvfx, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1.75f, selectScript.placementPos.z), Quaternion.identity);
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
            Instantiate(buildvfx, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1.75f, selectScript.placementPos.z), Quaternion.identity);
            GameObject child = Instantiate(blastFurnace, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1f, selectScript.placementPos.z), Quaternion.identity);
            child.name = "Blast Furnace";
            audio.Play();
            selectScript.deploymentPanel.SetActive(false);
            Destroy(selectScript.currentlySelected);
        }
    }

    public void RemoveSnowball()
    {
        selectScript.hasDeleted = true;

        cs.bubblesCount += 50;
        sellAudio.Play();
        GameObject block = Instantiate(buildingBlock, new Vector3(selectScript.turretPos.x, selectScript.turretPos.y - 1.8f, selectScript.turretPos.z), Quaternion.identity);
        block.name = "Build here!";
        Destroy(selectScript.currentlySelected);
        selectScript.upgradeSnowballPanel.SetActive(false);
    }

    public void RemoveFishDispenser()
    {
        selectScript.hasDeleted = true;
        sellAudio.Play();
        cs.bubblesCount += 80;
        GameObject block = Instantiate(buildingBlock, new Vector3(selectScript.turretPos.x, selectScript.turretPos.y - 1f, selectScript.turretPos.z), Quaternion.identity);
        block.name = "Build here!";
        Destroy(selectScript.currentlySelected);
        selectScript.upgradeFishDispencerPanel.SetActive(false);
    }

    public void RemovePiston()
    {
        selectScript.hasDeleted = true;
        sellAudio.Play();
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

    #region All Upgrades
    //Deploys an upgraded snowball
    public void SnowballUpgrade()
    {
        if (cs.bubblesCount >= 120)
        {
            cs.bubblesCount -= 120;
            Instantiate(buildvfx, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1.75f, selectScript.placementPos.z), Quaternion.identity);
            GameObject child = Instantiate(snowballUpgrade, new Vector3(selectScript.turretPos.x, selectScript.turretPos.y, selectScript.turretPos.z), Quaternion.identity);
            child.name = "Snowball Turret - Level 2";
            audio.Play();
            selectScript.upgradeSnowballPanel.SetActive(false);
            Destroy(selectScript.currentlySelected);
        }
    }

    //Deploys an upgraded snowball
    public void PoisonFishUpgrade()
    {
        if (cs.bubblesCount >= 150)
        {
            cs.bubblesCount -= 150;
            Instantiate(buildvfx, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1.75f, selectScript.placementPos.z), Quaternion.identity);
            GameObject child = Instantiate(fishDispenserUpgrade, new Vector3(selectScript.turretPos.x, selectScript.turretPos.y, selectScript.turretPos.z), Quaternion.identity);
            child.name = "Poison Fish Dispenser - Level 2";
            audio.Play();
            selectScript.upgradeFishDispencerPanel.SetActive(false);
            Destroy(selectScript.currentlySelected);
        }
    }

    //Deploys an upgraded snowball
    public void PistonUpgrade()
    {
        if (cs.bubblesCount >= 170)
        {
            cs.bubblesCount -= 170;
            Instantiate(buildvfx, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1.75f, selectScript.placementPos.z), Quaternion.identity);
            GameObject child = Instantiate(blastFurnaceUpgrade, new Vector3(selectScript.turretPos.x, selectScript.turretPos.y, selectScript.turretPos.z), Quaternion.identity);
            child.name = "Blast Furnace - Level 2";
            audio.Play();
            selectScript.upgradePistonPanel.SetActive(false);
            Destroy(selectScript.currentlySelected);
        }
    }
    #endregion

    #region Description Panel
    public void SnowBallCost()
    {
        snowPanel.SetActive(true);
    }

    public void SnowBallCostExit()
    {
        snowPanel.SetActive(false);
    }

    public void FishCost()
    {
        fishPanel.SetActive(true);
    }

    public void FishCostExit()
    {
        fishPanel.SetActive(false);
    }

    public void BlastCost()
    {
        blastPanel.SetActive(true);
    }

    public void BlastCostExit()
    {
        blastPanel.SetActive(false);
    }
    #endregion

    #region Upgrade Panel
    public void SnowballUpgradePanel()
    {
        snowUpgrade.SetActive(true);
    }

    public void SnowballUpgradeExit()
    {
        snowUpgrade.SetActive(false);
    }

    public void SnowSell()
    {
        snowSell.SetActive(true);
    }

    public void SnowSellExit()
    {
        snowSell.SetActive(false);
    }

    public void fishDispenseTurn()
    {
        fishTurn.SetActive(true);
    }

    public void fishDispenseTurnExit()
    {
        fishTurn.SetActive(false);
    }

    public void fishDispenseUpgrade()
    {
        fishUpgrade.SetActive(true);
    }

    public void fishDispenseUpgradeExit()
    {
        fishUpgrade.SetActive(false);
    }

    public void fishDispenseSell()
    {
        fishSell.SetActive(true);
    }

    public void fishDispenseSellExit()
    {
        fishSell.SetActive(false);
    }

    public void bfTurn()
    {
        blastfTurn.SetActive(true);
    }

    public void bfExit()
    {
        blastfTurn.SetActive(false);
    }

    public void bfUpgrade()
    {
        blastfUpgrade.SetActive(true);
    }

    public void bfUpgradeExit()
    {
        blastfUpgrade.SetActive(false);
    }

    public void bfSell()
    {
        blastfSell.SetActive(true);
    }

    public void bfSellExit()
    {
        blastfSell.SetActive(false);
    }
    #endregion
}
