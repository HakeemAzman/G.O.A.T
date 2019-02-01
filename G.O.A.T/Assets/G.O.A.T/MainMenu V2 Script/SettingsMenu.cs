using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public GameObject muteAudioButton;
    public GameObject unmuteAudioButton;
    bool audioMute = false;

    AudioSource aS;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        audioMute = false;
    }

    void Update()
    {
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
    }

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
    }




    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }
    
    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log(isFullscreen);
    }


}
