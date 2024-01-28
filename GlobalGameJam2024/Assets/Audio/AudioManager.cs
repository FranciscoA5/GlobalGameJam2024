using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
    {   
        //if there is more than 1 instance of audiomanager delete it
        if(instance == null) { 
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //dont destroy audiomanager while changing scenes
        DontDestroyOnLoad(gameObject);

        //details for each sound
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    //starting music
    private void Start()
    {   
        PlaySound("BackgroundMusic");
    }

    //function to play sound
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    //function to stop sound
    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null && s.source.isPlaying)
        {
            s.source.Stop();
        }
    }

}
