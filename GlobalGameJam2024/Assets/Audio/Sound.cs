using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

    //specifications for each sound

    public string name;

    public AudioClip clip;

    [Range(0f,2f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
}
