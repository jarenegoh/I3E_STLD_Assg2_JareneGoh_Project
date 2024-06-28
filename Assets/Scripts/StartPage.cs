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

    private void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);

        musicSlider.value = musicVolume;

        musicSlider.onValueChanged.AddListener(OnMusicSliderChanged);

    }

    public void OnMusicSliderChanged(float value)
    {
        AudioManager.instance.SetMusicVolume(value);
    }

    public void Play()
    {
        // Loads the Game Scene when the 'Play' button is clicked
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        // Quits the application 
        Application.Quit();
    }
}
