/*
 * Author: Jarene Goh
 * Date: 27 June 2024
 * Description: Script that controls the Potion Collectible
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCollectible : Interactable
{
    /// <summary>
    /// The sound played when the potion item is collected.
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// Indicates whether the player owns this potion item.
    /// </summary>
    public bool ownPotion;

    /// <summary>
    /// Handles the interaction when the player collects the potion item.
    /// If the player owns the medal, sets ownPotion to true, notifies GameManager, plays a collection sound,
    /// destroys the potion item, and logs the collection.
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the potion item.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);

        // Check if the player owns the medal
        bool ownMedal = GameManager.instance.OwnMedal();

        if (ownMedal)
        {
            // Player owns the potion
            ownPotion = true;
            GameManager.instance.SetOwnPotion(ownPotion); // Notify GameManager about owning the potion
            AudioManager.instance.PlaySFX(collectAudio, transform.position); // Play collection sound
            Destroy(gameObject); // Destroy the potion item
            UIChanger.instance.CollectibleTextFalse();
            Debug.Log("Collected"); // Log collection
        }
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this potion item.
    /// Shows the collectible interaction UI.
    /// </summary>
    /// <param name="other">The Collider of the object that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        UIChanger.instance.CollectibleTextTrue(); // Show collectible interaction UI
    }

    /// <summary>
    /// Called when another collider exits the trigger collider attached to this potion item.
    /// Hides the collectible interaction UI.
    /// </summary>
    /// <param name="other">The Collider of the object that exited the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        UIChanger.instance.CollectibleTextFalse(); // Hide collectible interaction UI
    }
}
