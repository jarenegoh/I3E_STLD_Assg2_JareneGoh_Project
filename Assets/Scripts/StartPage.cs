/*
 * Author: Jarene Goh
 * Date: 13 June 2024
 * Description: Script that controls the Start Page
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
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
