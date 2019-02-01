using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encyclopedia : MonoBehaviour {

    public GameObject blinkingText;

	// Use this for initialization
	void Start () {
        //StartCoroutine("StopBlinking");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackToGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    /*
    IEnumerator StopBlinking()
    {
        blinkingText.SetActive(true);

        yield return new WaitForSeconds(5f);

        blinkingText.SetActive(false);
        Debug.Log("Blinking Text off");
    }
    */
}
