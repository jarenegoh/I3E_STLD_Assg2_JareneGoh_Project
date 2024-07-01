/*
 * Author: Jarene Goh
 * Date: 24 June 2024
 * Description: Script that controls the Start Page
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the GameManager.
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// The player's maximum health.
    /// </summary>
    public float maxHealth = 100f;

    /// <summary>
    /// The player's current health.
    /// </summary>
    private float currentHealth;

    /// <summary>
    /// The height at which the player started falling.
    /// </summary>
    private float fallStartHeight;

    /// <summary>
    /// Indicates whether the player is currently falling.
    /// </summary>
    private bool isFalling;

    /// <summary>
    /// The minimum distance the player must fall to take damage.
    /// </summary>
    [SerializeField] private float minFallDistance = 5f;

    /// <summary>
    /// Multiplier for calculating fall damage.
    /// </summary>
    [SerializeField] private float damageMultiplier = 1f;

    /// <summary>
    /// Slider UI element to display the player's health.
    /// </summary>
    public Slider healthSlider;

    /// <summary>
    /// UI element to display upon player's death.
    /// </summary>
    public GameObject deathScreenUI;

    /// <summary>
    /// UI element for the pause screen.
    /// </summary>
    public GameObject PauseScreen;

    /// <summary>
    /// UI text element for displaying the score.
    /// </summary>
    public TextMeshProUGUI scoreText;

    /// <summary>
    /// UI text element for displaying medals or potions.
    /// </summary>
    public TextMeshProUGUI medalText;

    /// <summary>
    /// The player's current score.
    /// </summary>
    private int currentScore = 0;

    /// <summary>
    /// Indicates whether the player owns a medal.
    /// </summary>
    public bool ownMedal = false;

    /// <summary>
    /// Indicates whether the player owns a potion.
    /// </summary>
    public bool ownPotion = false;

    /// <summary>
    /// Reference to the player GameObject.
    /// </summary>
    private GameObject player;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            currentHealth = maxHealth;
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        InitializePlayer();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Called when the script is being destroyed.
    /// </summary>
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// Called when a scene is loaded.
    /// </summary>
    /// <param name="scene">The loaded scene.</param>
    /// <param name="mode">The scene load mode.</param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializePlayer();
        UpdateHealthUI();
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(false);
        }
    }

    /// <summary>
    /// Initializes the player by finding the player GameObject and updating the health UI.
    /// </summary>
    private void InitializePlayer()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            return;
        }

        UpdateHealthUI();
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(false);
        }
    }

    /// <summary>
    /// Increases the player's score.
    /// </summary>
    /// <param name="scoreAdded">The amount of score to add.</param>
    public void IncreaseScore(int scoreAdded)
    {
        currentScore += scoreAdded;
        scoreText.text = currentScore.ToString();
        Debug.Log(currentScore);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        if (player == null)
        {
            return;
        }

        if (!isFalling && !IsGrounded())
        {
            isFalling = true;
            fallStartHeight = player.transform.position.y;
        }

        if (isFalling && IsGrounded())
        {
            isFalling = false;
            float fallDistance = fallStartHeight - player.transform.position.y;
            if (fallDistance > minFallDistance)
            {
                ApplyFallDamage(fallDistance);
            }
        }
    }

    /// <summary>
    /// Checks if the player is grounded.
    /// </summary>
    /// <returns>True if the player is grounded, otherwise false.</returns>
    private bool IsGrounded()
    {
        return Physics.Raycast(player.transform.position, Vector3.down, 1.1f);
    }

    /// <summary>
    /// Applies fall damage to the player based on the fall distance.
    /// </summary>
    /// <param name="fallDistance">The distance the player fell.</param>
    private void ApplyFallDamage(float fallDistance)
    {
        float damage = (fallDistance - minFallDistance) * damageMultiplier;
        Debug.Log($"Fall damage: {damage}");
        TakeDamage(damage);
    }

    /// <summary>
    /// Updates the health UI to reflect the player's current health.
    /// </summary>
    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth;
        }
    }

    /// <summary>
    /// Reduces the player's health by a specified amount.
    /// </summary>
    /// <param name="amount">The amount of damage to apply.</param>
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log($"{amount} damage taken. Current health: {currentHealth}");
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthUI();
    }

    /// <summary>
    /// Handles the player's death.
    /// </summary>
    void Die()
    {
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(true);
        }
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Player has died.");
    }

    /// <summary>
    /// Loads the main menu scene.
    /// </summary>
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Destroy(gameObject);
    }

    /// <summary>
    /// Restarts the game by resetting health, score, and other player states.
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        UpdateHealthUI();
        currentScore = 0;
        scoreText.text = null;
        ownMedal = false;
        ownPotion = false;
        medalText.text = null;

        UIChanger.instance.CongratsBackgroundFalse();
        PauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Sets the player's medal ownership status.
    /// </summary>
    /// <param name="value">True if the player owns a medal, otherwise false.</param>
    public void SetOwnMedal(bool value)
    {
        ownMedal = value;
        medalText.text = "Medal";
        Debug.Log("Medal collected.");
    }

    /// <summary>
    /// Gets the player's medal ownership status.
    /// </summary>
    /// <returns>True if the player owns a medal, otherwise false.</returns>
    public bool OwnMedal()
    {
        return ownMedal;
    }

    /// <summary>
    /// Sets the player's potion ownership status.
    /// </summary>
    /// <param name="value">True if the player owns a potion, otherwise false.</param>
    public void SetOwnPotion(bool value)
    {
        ownPotion = value;
        medalText.text = "Potion";
        Debug.Log("Potion collected.");
    }

    /// <summary>
    /// Gets the player's potion ownership status.
    /// </summary>
    /// <returns>True if the player owns a potion, otherwise false.</returns>
    public bool OwnPotion()
    {
        return ownPotion;
    }

    /// <summary>
    /// Gets the player's current score.
    /// </summary>
    /// <returns>The current score.</returns>
    public int GetScore()
    {
        return currentScore;
    }

}
