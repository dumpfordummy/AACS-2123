using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Toggle toggle;

    public static bool fullScreen = false;
    public static bool isMuted;

    public void SetMusicVolume(float MusicVolume)
    {
        audioMixer.SetFloat("MusicVolume", MusicVolume);
    }

    public void SetInGameVolume(float InGameVolume)
    {
        audioMixer.SetFloat("InGameVolume", InGameVolume);
    }

    public void SetSoundEffectsVolume(float SoundEffectsVolume)
    {
        audioMixer.SetFloat("SoundEffectsVolume", SoundEffectsVolume);
    }

    public void SetMute(bool Muted)
    {
        if (Muted)
        {
            AudioListener.volume = 0;
            isMuted = true;

        }

        else
        {
            AudioListener.volume = 1;
            isMuted = false;
        }
    }

    public void OnEnable()
    {
        if(toggle != null)
        {
            toggle.GetComponent<Toggle>().isOn = fullScreen;
            GameObject.FindGameObjectWithTag("MuteCheckBox").GetComponent<Toggle>().isOn = isMuted;
        }     
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = fullScreen = isFullscreen;
    }
}
