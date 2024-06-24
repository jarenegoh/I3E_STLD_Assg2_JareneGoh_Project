/*
 * Author: Jarene Goh
 * Date: 24 June 2024
 * Description: Script that controls the Start Page
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool hasMedal = false;

    public TextMeshProUGUI scoreText;

    private int currentScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore(int scoreToAdd)
    {
        // Increase the score of the player by scoreToAdd
        currentScore += scoreToAdd;
        scoreText.text = currentScore.ToString();
    }

    public void SetHasMedal(bool real)
    {
        hasMedal = real;
        Debug.Log("real");
    }

    public bool HasMedal()
    {
        return hasMedal;
    }
}
