using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource sound;
    private GameObject enemy;
    public AudioClip batClip;

    void Update()
    {
        if (enemy == GameObject.Find("Bat"))
        {
            GetComponent<AudioSource>().clip = batClip;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
    }
}
