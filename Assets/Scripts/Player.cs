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
    Interactable currentInteractable;

    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    private void DetectInteractable()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, interactionDistance))
        {
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

    void OnPause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);

        DetectInteractable();
    }
}
