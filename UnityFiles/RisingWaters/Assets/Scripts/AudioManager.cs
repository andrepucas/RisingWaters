using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Audio[] sounds;

    public static AudioManager instance;
    
    // Start is called before the first frame update
    void Awake()
    {
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

        foreach (Audio s in sounds)
        {
            s.source              = gameObject.AddComponent<AudioSource>();
            s.source.clip         = s.clip;
            s.source.volume       = s.volume;
            s.source.spatialBlend = s.spatialBlend;
            s.source.loop         = s.loop;
        }
    }

    public void Play(string name, float volume)
    {
        Audio s = Array.Find(sounds, audio => audio.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        s.source.volume = volume;
        s.source.Play();
    }
}
