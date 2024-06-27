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
    public static GameManager instance;

    // Player attributes
    public float maxHealth = 100f;
    private float currentHealth;

    // Fall damage attributes
    private float fallStartHeight;
    private bool isFalling;
    [SerializeField] private float minFallDistance = 5f; // Minimum distance to start taking damage
    [SerializeField] private float damageMultiplier = 1f; // Multiplier for damage calculation

    // UI elements
    public Slider healthSlider;
    public GameObject deathScreenUI;
    public TextMeshProUGUI scoreText;

    // Player state variables
    private int currentScore = 0;
    public bool hasMedal = false;

    // Reference to the player
    private GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            currentHealth = maxHealth; // Initialize health here
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializePlayer();
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene loaded event
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from scene loaded event
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializePlayer();
        UpdateHealthUI();
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(false);
        }
    }

    private void InitializePlayer()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            return;
        }

        // Reapply the current health to the player
        UpdateHealthUI();
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(false);
        }
    }

    public void IncreaseScore(int scoreAdded)
    {
        currentScore += scoreAdded;
        scoreText.text = currentScore.ToString();
        Debug.Log(currentScore);
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        // Check for falling start
        if (!isFalling && !IsGrounded())
        {
            isFalling = true;
            fallStartHeight = player.transform.position.y;
        }

        // Check for landing
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

    private bool IsGrounded()
    {
        // Adjust this to fit your game's grounding logic, for example using Raycast
        return Physics.Raycast(player.transform.position, Vector3.down, 1.1f);
    }

    private void ApplyFallDamage(float fallDistance)
    {
        float damage = (fallDistance - minFallDistance) * damageMultiplier;
        Debug.Log($"Fall damage: {damage}");
        TakeDamage(damage);
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth;
        }
    }

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

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void SetHasMedal(bool value)
    {
        hasMedal = value;
        Debug.Log("You have collected the medal");
    }

    public bool HasMedal()
    {
        return hasMedal;
    }

    public int GetScore()
    {
        return currentScore;
    }
}
