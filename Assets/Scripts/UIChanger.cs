/*
 * Author: Jarene Goh
 * Date: 29 June 2024
 * Description: Script that controls the UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIChanger : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the UIChanger.
    /// </summary>
    public static UIChanger instance;

    /// <summary>
    /// Text element for door interaction messages.
    /// </summary>
    public TextMeshProUGUI doorText;

    /// <summary>
    /// Background element for door interaction messages.
    /// </summary>
    public GameObject doorBackground;

    /// <summary>
    /// Text element for collectible interaction messages.
    /// </summary>
    public TextMeshProUGUI collectibleText;

    /// <summary>
    /// Background element for collectible interaction messages.
    /// </summary>
    public GameObject collectibleBackground;

    /// <summary>
    /// Background element for congratulatory messages.
    /// </summary>
    public GameObject congratsBackground;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
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
    /// Activates the door interaction UI with a specified message.
    /// </summary>
    /// <param name="message">The message to display.</param>
    public void DoorTextTrue(string message)
    {
        doorText.text = message;
        doorBackground.SetActive(true);
    }

    /// <summary>
    /// Deactivates the door interaction UI.
    /// </summary>
    public void DoorTextFalse()
    {
        doorText.text = null;
        doorBackground.SetActive(false);
    }

    /// <summary>
    /// Activates the collectible interaction UI with a preset message.
    /// </summary>
    public void CollectibleTextTrue()
    {
        collectibleText.text = "Hit 'E' to interact";
        collectibleBackground.SetActive(true);
    }

    /// <summary>
    /// Deactivates the collectible interaction UI.
    /// </summary>
    public void CollectibleTextFalse()
    {
        collectibleText.text = null;
        collectibleBackground.SetActive(false);
    }

    /// <summary>
    /// Activates the congratulatory message UI.
    /// </summary>
    public void CongratsBackgroundTrue()
    {
        congratsBackground.SetActive(true);
    }

    /// <summary>
    /// Deactivates the congratulatory message UI.
    /// </summary>
    public void CongratsBackgroundFalse()
    {
        congratsBackground.SetActive(false);
    }
}
