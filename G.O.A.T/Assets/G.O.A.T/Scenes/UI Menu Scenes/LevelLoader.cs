using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("Prototype Level");
    }

    public void ToOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }  
    
    /*public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsychronously(sceneIndex));
    }
       
    IEnumerator LoadAsychronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(operation.progress);

            yield return null;
        }
    }
    */
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


}
