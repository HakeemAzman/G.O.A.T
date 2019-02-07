using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encyclopedia : MonoBehaviour {

    //public GameObject blinkingText;
    EncyclopediaSmoothFade fade;

    private float wt;

	// Use this for initialization
	void Start () {        
        fade = FindObjectOfType<EncyclopediaSmoothFade>();
                
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(fade.imageToFadeCompleted);
	}
     
    public void BackToGame()
    {
        /*
        StartCoroutine(fade.FadeOut());

        if (fade.imageToFadeCompleted == true)
        {
            SceneManager.LoadScene("MainMenu");            
        }
        */
        SceneManager.LoadScene("MainLevel");
    }
    
}
