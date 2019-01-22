using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deployment : MonoBehaviour
{
    [Header("Bullet Instantiate Point")]
    public GameObject turret;

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
        if(cs.bubblesCount >= 30)
        {
            cs.bubblesCount -= 30;
            GameObject child = Instantiate(turret, new Vector3(selectScript.placementPos.x, selectScript.placementPos.y + 1.5f, selectScript.placementPos.z), Quaternion.identity);
            audio.Play();
            Destroy(selectScript.currentlySelected);
        }
    }

    public void CameraMovement()
    {
        selectScript.fcm.enabled = true;
    }
}
