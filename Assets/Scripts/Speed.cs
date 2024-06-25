using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Interactable
{

    /// <summary>
    /// The amount by which the player's speed is increased.
    /// </summary>
    public float speedIncrease = 10.0f;

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