using UnityEngine;
using System.Collections;

public class soundsHandler : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip deathSound;

    private AudioSource Sounds;



    void Start()
    {
        Sounds = GetComponent<AudioSource>();
    }


    public void play_jumpSound()
    {
        Sounds.clip = jumpSound; Sounds.Play();
    }


    public void play_deathSound()
    {
        Sounds.clip = deathSound; Sounds.Play();
    }

}
