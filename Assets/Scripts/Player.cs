/*
 * Author: Jarene Goh
 * Date: 24 June 2024
 * Description: Script that controls the Player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The current interactable object the player is looking at.
    /// </summary>
    private Interactable currentInteractable;

    /// <summary>
    /// The player's camera used for detecting interactables.
    /// </summary>
    [SerializeField]
    private Transform playerCamera;

    /// <summary>
    /// The maximum distance at which the player can interact with objects.
    /// </summary>
    [SerializeField]
    private float interactionDistance;

    /// <summary>
    /// Detects interactable objects in front of the player.
    /// </summary>
    private void DetectInteractable()
    {
        RaycastHit hit;
        // Perform a raycast from the player's camera forward within the interaction distance
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, interactionDistance))
        {
            // Check if the object hit by the raycast has an Interactable component
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                Debug.Log("Interactable detected: " + interactable.name); // Debug log

                // If the detected interactable is different from the current one
                if (interactable != currentInteractable)
                {
                    // Remove the player from the current interactable's list if it's not null
                    if (currentInteractable != null)
                    {
                        currentInteractable.RemovePlayerInteractable(this);
                    }
                    // Update the current interactable and add the player to its list
                    currentInteractable = interactable;
                    currentInteractable.UpdatePlayerInteractable(this);
                }
            }
            else if (currentInteractable != null)
            {
                // If no interactable is detected, remove the player from the current interactable's list
                currentInteractable.RemovePlayerInteractable(this);
                currentInteractable = null;
            }
        }
        else if (currentInteractable != null)
        {
            // If the raycast does not hit anything, remove the player from the current interactable's list
            currentInteractable.RemovePlayerInteractable(this);
            currentInteractable = null;
        }
    }

    /// <summary>
    /// Updates the current interactable to a new interactable object.
    /// </summary>
    /// <param name="newInteractable">The new interactable object.</param>
    public void UpdateInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
    }

    /// <summary>
    /// Called when the player interacts with an interactable object.
    /// </summary>
    void OnInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact(this);
        }
    }

    /// <summary>
    /// Called when the game is paused.
    /// </summary>
    void OnPause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        // Draw a debug line in the editor to visualize the interaction raycast
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);

        // Detect interactable objects
        DetectInteractable();
    }
}
