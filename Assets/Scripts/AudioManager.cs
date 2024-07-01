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
    /// <summary>
    /// Singleton instance of the AudioManager.
    /// </summary>
    public static AudioManager instance;

    /// <summary>
    /// Reference to the AudioMixer controlling the audio settings.
    /// </summary>
    public AudioMixer audioMixer;

    /// <summary>
    /// Initializes the AudioManager instance. Ensures only one instance exists across scenes.
    /// </summary>
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

    /// <summary>
    /// Sets initial audio settings on start, retrieving values from PlayerPrefs.
    /// </summary>
    private void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        bool isMute = false;

        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
        MuteMusic(isMute);
    }

    /// <summary>
    /// Sets the volume level of the music.
    /// </summary>
    /// <param name="volume">The new volume level (0 to 1).</param>
    public void SetMusicVolume(float volume)
    {
        if (volume <= 0)
        {
            audioMixer.SetFloat("MusicVolume", -80f); // Mute music
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 25); // Set music volume based on logarithmic scale
        }

        PlayerPrefs.SetFloat("MusicVolume", volume); // Save volume setting in PlayerPrefs
    }

    /// <summary>
    /// Sets the volume level of the sound effects (SFX).
    /// </summary>
    /// <param name="volume">The new volume level (0 to 1).</param>
    public void SetSFXVolume(float volume)
    {
        if (volume <= 0)
        {
            audioMixer.SetFloat("SFXVolume", -80f); // Mute SFX
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 25); // Set SFX volume based on logarithmic scale
        }

        PlayerPrefs.SetFloat("SFXVolume", volume); // Save volume setting in PlayerPrefs
    }

    /// <summary>
    /// Mutes or unmutes the music.
    /// </summary>
    /// <param name="value">True to mute music, false to unmute.</param>
    public void MuteMusic(bool value)
    {
        if (value)
        {
            audioMixer.SetFloat("MusicVolume", -80f); // Mute music
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", 1.0f); // Set music volume to full
        }
    }

    /// <summary>
    /// Plays a sound effect (SFX) at a specified position in the scene.
    /// </summary>
    /// <param name="clip">The audio clip to play.</param>
    /// <param name="position">The position in the scene where the SFX should play.</param>
    public void PlaySFX(AudioClip clip, Vector3 position)
    {
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1.0f); // Get SFX volume from PlayerPrefs
        AudioSource.PlayClipAtPoint(clip, position, sfxVolume); // Play the SFX at the specified position with the specified volume
    }
}

    
