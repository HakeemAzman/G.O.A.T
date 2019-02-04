using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

    public Image imageToFade;
    public Image borderFade;
    public Image borderFade1;
    public Image sideFade;
    public Image sideFade1;

    public GameObject titlePopIn;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Fade();
    }

    void Fade()
    {
        imageToFade.color = Color.Lerp(imageToFade.color, Color.clear, Time.deltaTime);
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        yield return new WaitForSeconds(2f);

        borderFade.color = Color.Lerp(borderFade.color, Color.black, Time.deltaTime);
        borderFade1.color = Color.Lerp(borderFade1.color, Color.black, Time.deltaTime);
        sideFade.color = Color.Lerp(sideFade.color, Color.black, Time.deltaTime);
        sideFade1.color = Color.Lerp(sideFade1.color, Color.black, Time.deltaTime);

        yield return new WaitForSeconds(1.5f);
        titlePopIn.gameObject.SetActive(true);
    }
}
