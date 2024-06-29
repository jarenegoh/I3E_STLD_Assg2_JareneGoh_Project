/*
 * Author: Jarene Goh
 * Date: 27 June 2024
 * Description: Script that controls the Audio
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // Reference to the audio mixer
    public AudioMixer audioMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Load saved volume settings
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        bool isMute = false;

        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
        MuteMusic(isMute);
    }

    public void SetMusicVolume(float volume)
    {
        if (volume <= 0)
        {
            audioMixer.SetFloat("MusicVolume", -80f); // Minimum volume level (mute)
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 25);
        }

        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        if (volume <= 0)
        {
            audioMixer.SetFloat("SFXVolume", -80f); // Minimum volume level (mute)
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 25);
        }

        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void MuteMusic(bool value)
    {
        if(value)
        {
            audioMixer.SetFloat("MusicVolume", -80f);
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", 1.0f);
        }
    }

    public void PlaySFX(AudioClip clip, Vector3 position)
    {
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
        AudioSource.PlayClipAtPoint(clip, position, sfxVolume);
    }
}

    
