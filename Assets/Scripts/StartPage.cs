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
    public Slider musicSlider;
    public Slider sfxSlider;
    public Toggle musicToggle;

    private void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1.0f);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        musicSlider.onValueChanged.AddListener(OnMusicSliderChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXSliderChanged);
        musicToggle.onValueChanged.AddListener(ToggleMute);
    }

    public void ToggleMute(bool value)
    {
        AudioManager.instance.MuteMusic(value);
    }

    public void OnMusicSliderChanged(float value)
    {
        AudioManager.instance.SetMusicVolume(value);
    }

    public void OnSFXSliderChanged(float value)
    {
        AudioManager.instance.SetSFXVolume(value);
    }

    public void Play()
    {
        // Loads the Game Scene when the 'Play' button is clicked
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        // Quits the application 
        Application.Quit();
    }
}
