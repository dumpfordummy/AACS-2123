using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip batClip;
    public AudioClip crabClip;
    public AudioClip ratClip;
    public AudioClip slimeClip;
    public AudioClip golemClip;

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
        else if (GameObject.Find("Rat"))
        {
            GetComponent<AudioSource>().clip = ratClip;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Spiked Slime"))
        {
            GetComponent<AudioSource>().clip = slimeClip;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Golem Phase 1"))
        {
            GetComponent<AudioSource>().clip = golemClip;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Golem Phase 3"))
        {
            GetComponent<AudioSource>().clip = golemClip;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
    }
}
