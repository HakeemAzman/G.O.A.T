using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encyclopedia : MonoBehaviour {

    public GameObject blinkingText;
    EncyclopediaSmoothFade fade;

	// Use this for initialization
	void Start () {
        //StartCoroutine("StopBlinking");
        fade = FindObjectOfType<EncyclopediaSmoothFade>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackToGame()
    {
        StartCoroutine(fade.FadeOut());
        SceneManager.LoadScene("MainLevel");
    }
    
}
