/*
 * Author: Jarene Goh
 * Date: 28 June 2024
 * Description: Script that controls the Blue Collectible
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBlue : Interactable
{
    /// <summary>
    /// The audio clip played when the item is collected.
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// The score value added to the player's score when the item is collected.
    /// </summary>
    public int myScore = 5;

    /// <summary>
    /// Called when the player interacts with the collectible item. Increases the player's score, plays a collection sound, hides the collectible UI, logs the collection, and destroys the object.
    /// </summary>
    /// <param name="thePlayer">The player who interacted with the collectible item.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);

        // Increase player's score
        GameManager.instance.IncreaseScore(myScore);

        // Play collection sound at the item's position
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);

        // Hide collectible interaction UI
        UIChanger.instance.CollectibleTextFalse();

        // Log collection
        Debug.Log("Collected");

        // Destroy the collectible object
        Destroy(gameObject);
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this GameObject. Shows collectible interaction UI.
    /// </summary>
    /// <param name="other">The Collider of the object that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        UIChanger.instance.CollectibleTextTrue();
    }

    /// <summary>
    /// Called when another collider exits the trigger collider attached to this GameObject. Hides collectible interaction UI.
    /// </summary>
    /// <param name="other">The Collider of the object that exited the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        UIChanger.instance.CollectibleTextFalse();
    }
}
