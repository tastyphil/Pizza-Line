using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        PlayMusic("game");
    }

    public void PlayMusic(string n) {
        Sound s = Array.Find(musicSounds, x => x.name == n);

        if (s == null) {
            Debug.Log("Sound Not Found!");
        } else {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
        
    }

    public void PlaySFX(string n) {
        Sound s = Array.Find(sfxSounds, x => x.name == n);

        if (s == null) {
            Debug.Log("Sound Not Found!");
        } else {
            sfxSource.PlayOneShot(s.clip);
        }
        
    }
}
