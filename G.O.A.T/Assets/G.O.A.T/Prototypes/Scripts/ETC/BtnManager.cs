using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour {
    public GameObject spawner;

    public GameObject deploy;

    public void ready()
    {
        Destroy(deploy);
        spawner.SetActive(true);
    }

    public void fastForward()
    {
        Time.timeScale = 2;
    }
}
