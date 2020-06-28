using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Audio[] sounds;

    public static AudioManager instance;
    
    void Awake()
    {
        // Allows for the theme to be played across multiple scenes
        DontDestroyOnLoad(gameObject);
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Set audio source variables
        foreach (Audio s in sounds)
        {
            s.source              = gameObject.AddComponent<AudioSource>();
            s.source.clip         = s.clip;
            s.source.volume       = s.volume;
            s.source.loop         = s.loop;
            s.source.dopplerLevel = 0f;
        }
    }

    // Theme song is playing throughout the whole game
    void Start()
    {
        Play("Theme");
    }

    // Plays audio
    public void Play(string name)
    {
        Audio s = Array.Find(sounds, audio => audio.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        //if (PauseMenu.GameIsPaused)
        //{
        //    GetComponent<AudioSource>().mute;
        //}
        // Doesnt allow the same sound to be played on top of itself
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
    }
}
