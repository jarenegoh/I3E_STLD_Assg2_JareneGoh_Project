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
    public static UIChanger instance;

    public TextMeshProUGUI doorText;
    public GameObject doorBackground;

    public TextMeshProUGUI collectibleText;
    public GameObject collectibleBackground;

    public GameObject congratsBackground;

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

    public void DoorTextTrue(string message)
    {
        doorText.text = message;
        doorBackground.SetActive(true);
    }

    public void DoorTextFalse()
    {
        doorText.text = null;
        doorBackground.SetActive(false);
    }

    public void CollectibleTextTrue()
    {
        collectibleText.text = "Hit 'E' to interact";
        collectibleBackground.SetActive(true);
    }

    public void CollectibleTextFalse()
    {
        collectibleText.text = null;
        collectibleBackground.SetActive(false);
    }

    public void CongratsBackgroundTrue()
    {
        congratsBackground.SetActive(true);
    }

    public void CongratsBackgroundFalse()
    {
        congratsBackground.SetActive(false);
    }
}
