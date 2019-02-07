using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BtnManager : MonoBehaviour {
    public GameObject spawner;
    public AudioSource audio;
    public GameObject deploy;
    public GameObject tutorialtext;
    
    public bool isReady = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void ready()
    {
        deploy.SetActive(false);
        audio.Play();
        spawner.SetActive(true);
        isReady = true;
        
}

    public void fastForward()
    {
        Time.timeScale = 2;
    }

    public void hidePanel()
    {
        tutorialtext.SetActive(false);
    }
}
