using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public GameObject muteAudioButton;
    public GameObject unmuteAudioButton;

    bool audioMute = false;

    public GameObject fullScreenTrue;
    public GameObject fullScreenFalse;

    bool fullScreenisTrue;

    public Toggle fullscreenToggle;
    public Toggle musicToggle;
    bool audioisTrue;
    
    public float masterMusicVolume;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    AudioSource aS;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i =0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();


        aS = GetComponent<AudioSource>();
        audioMute = false;
        fullScreenisTrue = true;
        audioisTrue = true;

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        musicToggle.onValueChanged.AddListener(delegate { OnMusicToggle(); });
    }

    void Update()
    {
        /* OLD
        if (audioMute == false)
        {
            muteAudioButton.SetActive(true);
            unmuteAudioButton.SetActive(false);
        }
        else
        {
            unmuteAudioButton.SetActive(true);
            muteAudioButton.SetActive(false);
        }
        
        if (fullScreenisTrue == true)
        {
            fullScreenFalse.SetActive(false);
            fullScreenTrue.SetActive(true);
        }
        else
        {
            fullScreenTrue.SetActive(false);
            fullScreenFalse.SetActive(false);
        }
        */

        
    }
    /*
    public void MuteAudio()
    {
        audioMute = true;
        unmuteAudioButton.SetActive(true);
        muteAudioButton.SetActive(false);
        Debug.Log("Muted");
    }

    public void UnmuteAudio()
    {
        audioMute = false;
        unmuteAudioButton.SetActive(false);
        muteAudioButton.SetActive(true);
        Debug.Log("Unmuted");
    }*/

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }
    /*
    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log(isFullscreen);
    }
    */
    public void OnFullScreenToggle()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
        //Debug.Log(fullscreenToggle.isOn);
    }

    public void OnMusicToggle()
    {
        audioisTrue = musicToggle.isOn;
        Debug.Log(audioisTrue);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
