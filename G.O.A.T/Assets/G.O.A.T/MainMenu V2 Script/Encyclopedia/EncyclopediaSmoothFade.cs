using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EncyclopediaSmoothFade : MonoBehaviour {

    public Image imageToFade;
    public GameObject switchOffImage;



    void Start()
    {
        // SceneManager.sceneLoaded += OnSceneLoaded;
        Fade();
    }
    /*
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(Fade());
    }
    */
    /*
    void Update()
    {
        Fade();
    }
    */
     void Fade()
    {        
        switchOffImage.SetActive(true);
        imageToFade.color = Color.black;
        imageToFade.CrossFadeAlpha(0, 3f, false);
        StartCoroutine(OffFade());
    }
    
    IEnumerator OffFade()
    {
        yield return new WaitForSeconds(3f);

        switchOffImage.SetActive(false);
    }
    
    public IEnumerator FadeOut()
    {
        switchOffImage.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        imageToFade.CrossFadeAlpha(1, 3f, false);
    }

}
