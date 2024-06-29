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
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// The score value that this collectible is worth.
    /// </summary>
    public int myScore = 5;

    /// <summary>
    /// Handles the collectibles interaction.
    /// Increase the player's score and destroy itself
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the object.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        GameManager.instance.IncreaseScore(myScore);
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
        Debug.Log("Collected");
        Destroy(gameObject);
    }
}
