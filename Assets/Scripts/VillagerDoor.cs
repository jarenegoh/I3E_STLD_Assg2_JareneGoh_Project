/*
 * Author: Jarene Goh
 * Date: 27 June 2024
 * Description: Script that controls the Villager Door
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VillagerDoor : Interactable
{
    /// <summary>
    /// The audio source that plays when the door opens.
    /// </summary>
    [SerializeField]
    private AudioSource openAudio;

    /// <summary>
    /// The text displayed when the player can interact with the door.
    /// </summary>
    public TextMeshProUGUI doorText;

    /// <summary>
    /// The background object associated with the door text.
    /// </summary>
    public GameObject doorBackground;

    /// <summary>
    /// Handles the interaction when the player interacts with the door.
    /// Opens the door if the player owns the medal and has the required score.
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the door.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);

        // Check if the player owns the medal
        bool ownMedal = GameManager.instance.OwnMedal();

        // Get the current score of the player
        int currentScore = GameManager.instance.GetScore();

        if (currentScore >= 0)
        {
            OpenDoor();
        }
        else
        {
            Debug.Log("You don't have everything you need to enter the house!");
        }
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this door.
    /// Displays the interaction text and activates the door background.
    /// </summary>
    /// <param name="other">The Collider of the object that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player owns the medal
        bool ownMedal = GameManager.instance.OwnMedal();

        // Display interaction text and activate door background
        doorText.text = "Hit 'E' to interact!";
        doorBackground.SetActive(true);
    }

    /// <summary>
    /// Called when another collider exits the trigger collider attached to this door.
    /// Clears the interaction text and deactivates the door background.
    /// </summary>
    /// <param name="other">The Collider of the object that exited the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        // Clear interaction text and deactivate door background
        doorText.text = null;
        doorBackground.SetActive(false);
    }

    /// <summary>
    /// Opens the door by rotating it 90 degrees on the y-axis and plays the open audio.
    /// </summary>
    public void OpenDoor()
    {
        // Create a new Vector3 and store the current rotation.
        Vector3 newRotation = transform.eulerAngles;

        // Add 90 degrees to the y axis rotation
        newRotation.y += 90f;

        // Assign the new rotation to the transform
        transform.eulerAngles = newRotation;

        // Play the open door audio
        openAudio.Play();
    }
}
