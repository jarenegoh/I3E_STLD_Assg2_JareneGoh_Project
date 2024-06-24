using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Interactable currentInteractable;
    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    // Variables to track fall height
    private float fallStartHeight;
    private bool isFalling;

    // Variables for fall damage
    [SerializeField] private float minFallDistance = 5f; // Minimum distance to start taking damage
    [SerializeField] private float damageMultiplier = 1f; // Multiplier for damage calculation

    /// <summary>
    /// players max health
    /// </summary>
    public float maxHealth = 100f;

    /// <summary>
    /// players current health
    /// </summary>
    private float currentHealth;

    /// <summary>
    /// to reference health bar ui
    /// </summary>
    public Slider healthSlider;

    /// <summary>
    /// to reference death screen ui
    /// </summary>
    public GameObject deathScreenUI;

    private void DetectInteractable()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, interactionDistance))
        {
            Debug.Log("Raycast hit: " + hit.collider.name); // Debug log

            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                Debug.Log("Interactable detected: " + interactable.name); // Debug log

                if (interactable != currentInteractable)
                {
                    if (currentInteractable != null)
                    {
                        currentInteractable.RemovePlayerInteractable(this);
                    }
                    currentInteractable = interactable;
                    currentInteractable.UpdatePlayerInteractable(this);
                }
            }
            else if (currentInteractable != null)
            {
                currentInteractable.RemovePlayerInteractable(this);
                currentInteractable = null;
            }
        }
        else if (currentInteractable != null)
        {
            currentInteractable.RemovePlayerInteractable(this);
            currentInteractable = null;
        }
    }

    public void UpdateInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
    }

    void OnInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact(this);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        DetectInteractable();

        // Check for falling start
        if (!isFalling && !IsGrounded())
        {
            isFalling = true;
            fallStartHeight = transform.position.y;
        }

        // Check for landing
        if (isFalling && IsGrounded())
        {
            isFalling = false;
            float fallDistance = fallStartHeight - transform.position.y;
            if (fallDistance > minFallDistance)
            {
                ApplyFallDamage(fallDistance);
            }
        }
    }

    private bool IsGrounded()
    {
        // Adjust this to fit your game's grounding logic, for example using Raycast
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    private void ApplyFallDamage(float fallDistance)
    {
        float damage = (fallDistance - minFallDistance) * damageMultiplier;
        Debug.Log($"Fall damage: {damage}");
        TakeDamage(damage);
    }


    /// <summary>
    /// to set health and checkpoint position when character first spawns
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        deathScreenUI.SetActive(false); // Ensure the death screen is hidden at the start
    }

    /// <summary>
    /// to update health bar ui when damage taken
    /// </summary>
    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    /// <summary>
    /// to update health when damage taken and what happens when the character reaches 0 health
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log($"{amount} {currentHealth}");
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthUI();
    }

    /// <summary>
    /// what happens when character dies
    /// </summary>
    void Die()
    {
        deathScreenUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Player has died.");
    }

    /// <summary>
    /// to load main menu from death screen ui
    /// </summary>
    public void LoadStartPage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartPage");
    }
}
