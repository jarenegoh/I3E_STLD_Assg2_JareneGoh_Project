/*
 * Author: Jarene Goh
 * Date: 24 June 2024
 * Description: Script that controls the Interactables
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    /// <summary>
    /// Updates the player's current interactable to this object.
    /// </summary>
    /// <param name="thePlayer">The player who is interacting with this object.</param>
    public void UpdatePlayerInteractable(Player thePlayer)
    {
        thePlayer.UpdateInteractable(this);
    }

    /// <summary>
    /// Removes this object as the player's current interactable.
    /// </summary>
    /// <param name="thePlayer">The player who is no longer interacting with this object.</param>
    public void RemovePlayerInteractable(Player thePlayer)
    {
        thePlayer.UpdateInteractable(null);
    }

    /// <summary>
    /// Called when the player interacts with this object. Can be overridden by subclasses to provide specific interaction behavior.
    /// </summary>
    /// <param name="thePlayer">The player who interacted with this object.</param>
    public virtual void Interact(Player thePlayer)
    {
        Debug.Log(gameObject.name + " was interacted with");
    }
}
