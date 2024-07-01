/*
* Author: Jarene Goh
* Date: 24 June 2024
* Description: Script that controls the Medal Collectible
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedalCollectible : Interactable
{
    /// <summary>
    /// The sound that plays when the medal is collected.
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// Indicates whether the player has the medal.
    /// </summary>
    public bool ownMedal;

    /// <summary>
    /// Called when the player interacts with the medal. Sets the medal as owned, updates the game manager, plays a collection sound, and destroys the medal.
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        ownMedal = true;
        GameManager.instance.SetOwnMedal(ownMedal);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 0.5f);
        UIChanger.instance.CollectibleTextFalse();
        Debug.Log("Collected");
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
