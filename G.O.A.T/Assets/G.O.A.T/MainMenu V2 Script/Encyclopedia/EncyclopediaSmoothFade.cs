using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EncyclopediaSmoothFade : MonoBehaviour {

    public Image imageToFadeIn;
    public Image imageToFadeOut;
    public GameObject fadeInImage;
    public GameObject fadeOutImage;

    public bool imageToFadeCompleted;

    void Start()
    {       
        Fade();

        imageToFadeCompleted = false;
    }

     void Fade()
    {
        fadeInImage.SetActive(true);
        imageToFadeIn.color = Color.black;
        imageToFadeIn.CrossFadeAlpha(0, 3f, false);
        StartCoroutine(OffFade());
    }
    
    IEnumerator OffFade()
    {
        yield return new WaitForSeconds(3f);

        fadeInImage.SetActive(false);
    }
    
     public IEnumerator FadeOut()
    {
        fadeOutImage.SetActive(true);
        imageToFadeOut.CrossFadeAlpha(1, 3f, false);
        yield return new WaitForSeconds(3f);

        imageToFadeCompleted = true;
    }

}
