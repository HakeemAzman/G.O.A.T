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

    bool isFastForward;
    public GameObject fastForwardButton;

    private void Awake()
    {
        fastForwardButton.SetActive(false);
    }

    private void Update()
    {
      if(isReady == true)
        {
            fastForwardButton.SetActive(true);
        }
    }

    public void ready()
    {
        deploy.SetActive(false);
        audio.Play();
        spawner.SetActive(true);
        isReady = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void fastForward()
    {
        if(!isFastForward)
        {
            Time.timeScale = 2;
            isFastForward = true;
        }

        else if (isFastForward)
        {
            Time.timeScale = 1f;
            isFastForward = false;
        }
    }

    public void hidePanel()
    {
        tutorialtext.SetActive(false);
    }
}
