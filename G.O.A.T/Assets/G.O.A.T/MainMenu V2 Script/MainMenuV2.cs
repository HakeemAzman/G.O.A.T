using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuV2 : MonoBehaviour
{
    public Animator m_Anim;

    bool startInitiated = false;    // Start smooth splash loading
    bool mainMenuNavi = false;      // Don't allow navigation of main menu

    public GameObject loadIn;
    public GameObject fadeAway;
    public Image fadeAwayImage;

    public GameObject titleScreenHolder;

    public GameObject quitPrompt;            
   
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;

        m_Anim = GetComponent<Animator>();
        startInitiated = false;
        mainMenuNavi = false;

        GameLoad();

        StartCoroutine(BlinkingTextSetTrue());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && mainMenuNavi == true )
        {            
            GameStart();
            Debug.Log("hi");
        }

        if (startInitiated == true)
        {            
            m_Anim.SetBool("StartBlinking", true);
            mainMenuNavi = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))       // Quit Prompt
        {
            quitPrompt.SetActive(true);
        }

    }

    void GameLoad()
    {
        fadeAway.SetActive(true);
        fadeAwayImage.color = Color.black;
        fadeAwayImage.CrossFadeAlpha(0, 2f, false);
        StartCoroutine(FadeAwayOff());
    }

    IEnumerator FadeAwayOff()       // 3s Delay
    {
        yield return new WaitForSeconds (3f);
        fadeAway.SetActive(false);
        startInitiated = true;
    }

    IEnumerator BlinkingTextSetTrue()       
    {
        yield return new WaitForSeconds(3f);
        loadIn.SetActive(true);
    }

    void GameStart()
    {
        loadIn.SetActive(false);        
        m_Anim.SetBool("MainMenuStart", true);
        StartCoroutine(TitleScreenHolderTrue());
    }

    IEnumerator TitleScreenHolderTrue()
    {
        yield return new WaitForSeconds(4.5f);
        titleScreenHolder.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }




}
