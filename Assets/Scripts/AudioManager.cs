using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public  Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    //
    //  FindObjectOfType<AudioManager>().Play("soundName") to play the requested soundName
    // FindObjectOfType<AudioManager>().Stop("soundName") to stop the requested animation if loop is set to true
    //
    //
    // 
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            audioMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
        }

        if (PlayerPrefs.HasKey("MusicVol"))
        {
            audioMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
        }

        if (PlayerPrefs.HasKey("SFXVol"))
        {
            audioMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
        }
    }

    
    public void Play(string name)
    {
        //
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        if (s != null)
        {
            if(!s.source.isPlaying)
                s.source.Play();

           
        }
        else
        {
            Debug.LogWarning("The sound: " + name + " was not found");
            return;
        }
        
    }
    public void Stop(string name)
    {
        //Debug.Log("Stopping");
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            if(s.source.isPlaying)
                s.source.Stop();
            
        }
        else
        {
            Debug.LogWarning("The sound: " + name + " was not found");
            return;
        }
        
    }
    public bool isPlaying(string name)
    {
        bool result;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying)
        {
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }
}
