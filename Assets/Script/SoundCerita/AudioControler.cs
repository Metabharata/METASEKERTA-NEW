using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool loop;
    private AudioSource source;

    public void SetSource(AudioSource audioSource)
    {
        source = audioSource;
        source.clip = clip;
    }

    public void Play()
    {
        source.loop = loop;
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void SetVolume(float volume)
    {
        source.volume = volume;
    }
}

public class AudioControler : MonoBehaviour
{
    public static AudioControler audioControler;
    [SerializeField]
    private Sound[] sounds;

    void Awake()
    {
        if (audioControler == null)
        {
            DontDestroyOnLoad(gameObject);
            audioControler = this;
        }
        else if (audioControler != this)
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject go = new GameObject("sound_" + i + "_" + sounds[i].name);
            go.transform.SetParent(this.transform);
            sounds[i].SetSource(go.AddComponent<AudioSource>());
        }
    }

    private void Start()
    {
        // Inisialisasi volume BGM dan efek suara jika perlu
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        float soundEffectVolume = PlayerPrefs.GetFloat("SoundEffectVolume", 1.0f);
        SetBGMVolume(bgmVolume);
        SetSoundEffectVolume(soundEffectVolume);
    }

    private void Update()
    {

    }

    public void PlaySound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                sounds[i].Play();
                return;
            }
        }
    }

    public void PlayBGMSound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                sounds[i].Play();
                return;
            }
        }
    }

    public void StopSound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }

    public void AllStopSound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Stop();
        }
    }

    public void SetBGMVolume(float volume)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].loop)
            {
                sounds[i].SetVolume(volume);
            }
        }
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSoundEffectVolume(float volume)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (!sounds[i].loop)
            {
                sounds[i].SetVolume(volume);
            }
        }
        PlayerPrefs.SetFloat("SoundEffectVolume", volume);
    }
}
