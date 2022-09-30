using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer inGameMixer;
    public AudioMixer soundEffectsMixer;

    public Toggle toggle;

    public static bool fullScreen = true;
    public static bool isMuted;

    public void SetMusicVolume(float MusicVolume)
    {
        inGameMixer.SetFloat("MusicVolume", MusicVolume);
    }

    public void SetInGameVolume(float InGameVolume)
    {
        inGameMixer.SetFloat("InGameVolume", InGameVolume);
    }

    public void SetSoundEffectsVolume(float SoundEffectsVolume)
    {
        soundEffectsMixer.SetFloat("SoundEffectsVolume", SoundEffectsVolume);
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
