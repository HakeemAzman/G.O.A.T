using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerExpansion : MonoBehaviour {


    List<GameObject> towerPartList = new List<GameObject>();

    public GameObject[] tower;

    CurrencySystem cs;

    bool buildingTrigger = false;


    // Use this for initialization
    void Start () {
       cs = FindObjectOfType<CurrencySystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       // Debug.Log(buildingTrigger);
       // Debug.Log(tower[1].activeInHierarchy);       
    }

    public void UpgradeButtonPressed()
    {
         if (buildingTrigger == true)
             buildingTrigger = false;
         else
            buildingTrigger = true;

        // Price value of the towers can be changed in under the SubtractBubbles and cs.bubbleCount

        if (tower[3].activeInHierarchy == true && buildingTrigger == true && cs.bubblesCount >= 500)
        {
            cs.SubtractBubbles(500);
            tower[4].SetActive(true);
        }
        else if (tower[2].activeInHierarchy == true && buildingTrigger == false && cs.bubblesCount >= 400)
        {
            cs.SubtractBubbles(400);
            tower[3].SetActive(true);
        }
        else if (tower[1].activeInHierarchy == true && buildingTrigger == true && cs.bubblesCount >= 300)
        {
            cs.SubtractBubbles(300);
            tower[2].SetActive(true);
        }
        else if (tower[0].activeInHierarchy == true && buildingTrigger == false && cs.bubblesCount >= 200)
        {
            cs.SubtractBubbles(200);
            tower[1].SetActive(true);
        }
        else if (tower[0].activeInHierarchy == false && buildingTrigger == true && cs.bubblesCount >= 100)
        {
            cs.SubtractBubbles(100);
            tower[0].SetActive(true);
        }

          /* if (tower[0].activeInHierarchy == false && buildingTrigger == true && cs.bubblesCount >= 100)
         {
             cs.SubtractBubbles(100);
             tower[0].SetActive(true);
         }
         else if (tower[0].activeInHierarchy == true && buildingTrigger == false && cs.bubblesCount >= 200)
         {
             cs.SubtractBubbles(200);
             tower[1].SetActive(true);
         }
         else if (tower[1].activeInHierarchy == true && buildingTrigger == true && cs.bubblesCount >= 500)
         {
             cs.SubtractBubbles(500);
             tower[2].SetActive(true);
         }
         else if (tower[2].activeInHierarchy == true && buildingTrigger == false && cs.bubblesCount >= 500)
         {
             cs.SubtractBubbles(500);
             tower[3].SetActive(true);
         }
         else if(tower[3].activeInHierarchy == true && buildingTrigger == true && cs.bubblesCount >= 500)
         {
             cs.SubtractBubbles(500);
             tower[4].SetActive(true);
         } */
    }
}
