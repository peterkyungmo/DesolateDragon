using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{


    public Sound[] sounds;

    // Use this for initialization
    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;

            sound.source.pitch = sound.pitch;

            sound.source.loop = sound.loop;
        }

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("No music");
            return;
        }
        s.source.Play();
    }

    private void Start()
    {
        Play("Theme");
    }

}
