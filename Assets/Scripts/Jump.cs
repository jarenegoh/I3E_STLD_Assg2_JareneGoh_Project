/*
 * Author: Jarene Goh
 * Date: 25 June 2024
 * Description: Script that controls the Jump Boost
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Jump : Interactable
{
    /// <summary>
    /// The amount by which the player's jump height is increased.
    /// </summary>
    public float jumpIncrease = 3.0f;

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The Collider of the object that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        UIChanger.instance.CollectibleTextTrue();
    }

    /// <summary>
    /// Called when another collider exits the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The Collider of the object that exited the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        UIChanger.instance.CollectibleTextFalse();
    }

    /// <summary>
    /// Called when the player collects the item. Increases the player's jump height.
    /// </summary>
    /// <param name="thePlayer">The player who collected the item.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        thePlayer.GetComponent<StarterAssets.FirstPersonController>().JumpHeight += jumpIncrease;
        UIChanger.instance.CollectibleTextFalse();
        Debug.Log(thePlayer.GetComponent<StarterAssets.FirstPersonController>().JumpHeight);
        Destroy(gameObject);
    } 
}
