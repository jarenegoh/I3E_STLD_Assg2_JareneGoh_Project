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
    /// sound when collected
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// bool for whether player has crystal
    /// </summary>
    public bool ownMedal;

    /// <summary>
    /// function for interacting with the crystal
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        ownMedal = true;
        GameManager.instance.SetOwnMedal(ownMedal);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 0.5f);
        Debug.Log("Collected");
    }
}
