using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip batClip;
    public AudioClip crabClip;

    void Update()
    {
        if (GameObject.Find("Bat"))
        {
            GetComponent<AudioSource>().clip = batClip;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Crab"))
        {
            GetComponent<AudioSource>().clip = crabClip;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
    }
}
