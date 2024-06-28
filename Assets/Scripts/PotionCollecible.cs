using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCollectible : Interactable
{
    /// <summary>
    /// bool for whether player has crystal
    /// </summary>
    public bool ownPotion;

    /// <summary>
    /// function for interacting with the crystal
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        bool hasMedal = GameManager.instance.HasMedal();
        base.Interact(thePlayer);
       
        if(hasMedal)
        {
            ownPotion = true;
            GameManager.instance.SetHasPotion(ownPotion);
            Destroy(gameObject);
            Debug.Log("Collected");
        }
    }
}
