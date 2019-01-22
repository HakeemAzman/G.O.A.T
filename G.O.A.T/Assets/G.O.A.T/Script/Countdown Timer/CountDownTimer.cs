using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour {

    public int timeLeft = 60;
    public Text countdownText;

    bool countDownTimerActive = true;

    public GameObject imageGO;
    public Image imageToAppear;

    public string LevelToLoad;

    //LevelLoader ll;

	// Use this for initialization
	void Start () {
        // ll = FindObjectOfType<LevelLoader>();

        imageGO.SetActive(false);        

        StartCoroutine("LoseTime");
        countDownTimerActive = true;

        //Debug.Log("ImageGO - false");
    }
	
	// Update is called once per frame
	void Update () {

        countdownText.text = ("Time Left: " + timeLeft + "s");

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Times Up!";
            countDownTimerActive = false;
        }

        if (countDownTimerActive == false)
        {
            StartCoroutine("GameOverTransition");
        }
	}

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;            
        }
    }

    IEnumerator GameOverTransition()
    {
        imageGO.SetActive(true);

       // Debug.Log("ImageGO - true");

        yield return new WaitForSeconds(1f);

        imageToAppear.color = Color.Lerp(imageToAppear.color, Color.black, Time.deltaTime);

        yield return new WaitForSeconds(5f);

        StartCoroutine("LoadGameOverScene");        
    }

    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(0);

        SceneManager.LoadScene("GameOver Screen");
    }

}
