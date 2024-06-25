using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Interactable
{
    
    /// <summary>
    /// The amount by which the player's jump height is increased.
    /// </summary>
    public float jumpIncrease = 10.0f;

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
