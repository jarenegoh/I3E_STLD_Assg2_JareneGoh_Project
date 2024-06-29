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
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// The score value that this collectible is worth.
    /// </summary>
    public int myScore = 1;

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
        UIChanger.instance.CollectibleTextFalse();
        Debug.Log("Collected");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        UIChanger.instance.CollectibleTextTrue();
    }

    private void OnTriggerExit(Collider other)
    {
        UIChanger.instance.CollectibleTextFalse();
    }

}
