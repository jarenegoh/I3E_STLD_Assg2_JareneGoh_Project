/*
 * Author: Jarene Goh
 * Date: 30 June 2024
 * Description: Script that controls the Final Scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Exit : Interactable
{
    /// <summary>
    /// The audio clip played when the door opens.
    /// </summary>
    [SerializeField]
    private AudioClip openAudio;

    /// <summary>
    /// Handles the interaction when the player interacts with the potion door.
    /// Activates congratulations UI and plays the open audio if the player owns the potion.
    /// Otherwise, displays a message requiring the potion.
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the potion door.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);

        // Check if the player owns the potion
        bool ownPotion = GameManager.instance.OwnPotion();

        if (ownPotion)
        {
            UIChanger.instance.CongratsBackgroundTrue(); // Show congratulations UI
            AudioSource.PlayClipAtPoint(openAudio, transform.position, 0.5f); // Play open audio
            ownPotion = false;
            GameManager.instance.medalText.text = null;
        }
        else
        {
            UIChanger.instance.DoorTextTrue("Fix-It-All potion required!"); // Display potion requirement message
        }
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this potion door.
    /// Displays the interaction text based on whether the player owns the potion or not.
    /// </summary>
    /// <param name="other">The Collider of the object that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player owns the potion
        bool ownPotion = GameManager.instance.OwnPotion();

        if (ownPotion == false)
        {
            UIChanger.instance.DoorTextTrue("You need the Fix-It-All potion!"); // Display potion requirement message
        }
        else
        {
            UIChanger.instance.DoorTextTrue("Hit 'E' to interact!"); // Display interaction prompt
        }
    }

    /// <summary>
    /// Called when another collider exits the trigger collider attached to this potion door.
    /// Clears the interaction text.
    /// </summary>
    /// <param name="other">The Collider of the object that exited the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        UIChanger.instance.DoorTextFalse(); // Clear interaction text
    }
}
