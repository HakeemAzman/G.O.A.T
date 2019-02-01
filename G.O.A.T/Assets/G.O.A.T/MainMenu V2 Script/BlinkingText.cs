using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour {

    Text text;
    public GameObject blinkingText;

    bool isBlinking;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();        
        StartCoroutine("StartBlinking");
        
        isBlinking = true;
	}
    /*
    private void Update()
    {
        Debug.Log(isBlinking);
    }*/

    IEnumerator Blink ()
    {
        while (isBlinking == true)
        {
            switch (text.color.a.ToString())
            {
                case "0":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                        //PlaySound
                        yield return new WaitForSeconds(0.5f);
                    break;

                case "1":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                        //PlaySound
                        yield return new WaitForSeconds(0.5f);
                    break;
            }
        }        
    }

    IEnumerator StartBlinking()
    {
        isBlinking = true;
        StopCoroutine("Blink");
        StartCoroutine("Blink");

        yield return new WaitForSeconds(1f);

       // StopBlinking();
    }

    void StopBlinking ()
    {
        isBlinking = false;
        blinkingText.SetActive(false);
    }        
}
