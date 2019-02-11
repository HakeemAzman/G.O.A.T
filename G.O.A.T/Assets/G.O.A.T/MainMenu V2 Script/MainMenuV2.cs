using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuV2 : MonoBehaviour
{
   
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


}
