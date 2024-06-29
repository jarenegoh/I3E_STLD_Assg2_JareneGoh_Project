/*
 * Author: Jarene Goh
 * Date: 25 June 2024
 * Description: Script that controls the Speed Boost
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speed : Interactable
{
    public TextMeshProUGUI speedText;
    public GameObject speedBackground;

    /// <summary>
    /// The amount by which the player's speed is increased.
    /// </summary>
    public float speedIncrease = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        speedText.text = "Hit 'E' to interact";
        speedBackground.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        speedText.text = null;
        speedBackground.SetActive(false);
    }

    /// <summary>
    /// Called when the player collects the item. Increases the player's speed.
    /// </summary>
    /// <param name="thePlayer">The player who collected the item.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        thePlayer.GetComponent<StarterAssets.FirstPersonController>().MoveSpeed += speedIncrease;
        Debug.Log(thePlayer.GetComponent<StarterAssets.FirstPersonController>().MoveSpeed);
        Destroy(gameObject);

    }
    
}