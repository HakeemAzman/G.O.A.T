using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour {
    public GameObject spawner;
    public AudioSource audio;
    public GameObject deploy;
    public GameObject tutorialtext;
    public void ready()
    {
        Destroy(deploy);
        audio.Play();
        spawner.SetActive(true);
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
