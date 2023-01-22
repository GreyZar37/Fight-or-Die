using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioSource SFX;
    public AudioSource Music;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(AudioClip[] sound, int volume)
    {
        SFX.PlayOneShot(sound[Random.Range(0,sound.Length)], volume);
    }

    public void playMusic(AudioClip music, int volume)
    {
        Music.PlayOneShot(music, volume);
    }
}
