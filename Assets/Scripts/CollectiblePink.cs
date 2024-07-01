/*
 * Author: Jarene Goh
 * Date: 24 June 2024
 * Description: Script that controls the Pink Collectible
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePink : Interactable
{
    /// <summary>
    /// The sound played when the collectible item is collected.
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// The score value that this collectible item is worth when collected.
    /// </summary>
    public int myScore = 1;

    /// <summary>
    /// Handles the interaction when the player collects the collectible item.
    /// Increases the player's score, plays a collection sound, hides the collectible UI,
    /// logs the collection, and destroys the collectible item game object.
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the collectible item.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);

        // Increase the player's score
        GameManager.instance.IncreaseScore(myScore);

        // Play the collection sound at the collectible item's position
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);

        // Hide the collectible interaction UI
        UIChanger.instance.CollectibleTextFalse();

        // Log that the collectible item was collected
        Debug.Log("Collected");

        // Destroy the collectible item game object
        Destroy(gameObject);
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this collectible item.
    /// Shows the collectible interaction UI.
    /// </summary>
    /// <param name="other">The Collider of the object that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        UIChanger.instance.CollectibleTextTrue();
    }

    /// <summary>
    /// Called when another collider exits the trigger collider attached to this collectible item.
    /// Hides the collectible interaction UI.
    /// </summary>
    /// <param name="other">The Collider of the object that exited the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        UIChanger.instance.CollectibleTextFalse();
    }

}
