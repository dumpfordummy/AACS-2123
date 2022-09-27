using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

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
        }

        else
        {
            AudioListener.volume = 1;
        }
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
