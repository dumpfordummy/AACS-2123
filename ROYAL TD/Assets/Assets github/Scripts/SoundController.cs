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
    private GameObject enemyHolder;

    void Update()
    {
        if (GameObject.Find("Bat"))
        {
            GetComponent<AudioSource>().clip = batClip;
            GetComponent<AudioSource>().volume = 0.2f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Crab"))
        {
            GetComponent<AudioSource>().clip = crabClip;
            GetComponent<AudioSource>().volume = 0.05f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Rat"))
        {
            GetComponent<AudioSource>().clip = ratClip;
            GetComponent<AudioSource>().volume = 0.2f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Spiked Slime"))
        {
            GetComponent<AudioSource>().clip = slimeClip;
            GetComponent<AudioSource>().volume = 0.2f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Golem Phase 1"))
        {
            GetComponent<AudioSource>().clip = golemClip;
            GetComponent<AudioSource>().volume = 0.2f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Golem Phase 3"))
        {
            GetComponent<AudioSource>().clip = golemClip;
            GetComponent<AudioSource>().volume = 0.2f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else
        {
            sound.clip = null;
        }

    }
}
