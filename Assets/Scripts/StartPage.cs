/*
 * Author: Jarene Goh
 * Date: 13 June 2024
 * Description: Script that controls the Start Page
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPage : MonoBehaviour
{
    /// <summary>
    /// Slider to control the music volume.
    /// </summary>
    public Slider musicSlider;

    /// <summary>
    /// Slider to control the SFX volume.
    /// </summary>
    public Slider sfxSlider;

    /// <summary>
    /// Toggle to mute/unmute the music.
    /// </summary>
    public Toggle musicToggle;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        // Retrieve saved music and SFX volumes from PlayerPrefs, defaulting to 1.0 if not found
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1.0f);

        // Set slider values to the retrieved volumes
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        // Add listeners to handle slider and toggle value changes
        musicSlider.onValueChanged.AddListener(OnMusicSliderChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXSliderChanged);
        musicToggle.onValueChanged.AddListener(ToggleMute);
    }

    /// <summary>
    /// Toggles music muting based on the provided value.
    /// </summary>
    /// <param name="value">True to mute music, false to unmute.</param>
    public void ToggleMute(bool value)
    {
        AudioManager.instance.MuteMusic(value);
    }

    /// <summary>
    /// Updates the music volume when the music slider value changes.
    /// </summary>
    /// <param name="value">The new music volume value.</param>
    public void OnMusicSliderChanged(float value)
    {
        AudioManager.instance.SetMusicVolume(value);
    }

    /// <summary>
    /// Updates the SFX volume when the SFX slider value changes.
    /// </summary>
    /// <param name="value">The new SFX volume value.</param>
    public void OnSFXSliderChanged(float value)
    {
        AudioManager.instance.SetSFXVolume(value);
    }

    /// <summary>
    /// Loads the game scene.
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene(3);
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
