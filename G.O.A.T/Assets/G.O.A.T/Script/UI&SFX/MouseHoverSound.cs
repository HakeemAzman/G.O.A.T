using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverSound : MonoBehaviour
{
    AudioSource audio;
    public AudioClip hoverSnd;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnMouseEnter()
    {
        audio.PlayOneShot(hoverSnd, 0.2f);
    }
}
