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
    public TextMeshProUGUI jumpText;
    public GameObject jumpBackground;

    /// <summary>
    /// The amount by which the player's jump height is increased.
    /// </summary>
    public float jumpIncrease = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
            jumpText.text = "Hit 'E' to interact";
            jumpBackground.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        jumpText.text = null;
        jumpBackground.SetActive(false);
    }

    /// <summary>
    /// Called when the player collects the item. Increases the player's jump height.
    /// </summary>
    /// <param name="thePlayer">The player who collected the item.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        thePlayer.GetComponent<StarterAssets.FirstPersonController>().JumpHeight += jumpIncrease;
        Debug.Log(thePlayer.GetComponent<StarterAssets.FirstPersonController>().JumpHeight);
        Destroy(gameObject);
    }
    
}
