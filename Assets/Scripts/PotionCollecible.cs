using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCollectible : Interactable
{
    [SerializeField]
    private AudioClip collectAudio;

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
        bool ownMedal = GameManager.instance.OwnMedal();
        base.Interact(thePlayer);
       
        if(ownMedal)
        {
            ownPotion = true;
            GameManager.instance.SetOwnPotion(ownPotion);
            AudioManager.instance.PlaySFX(collectAudio, transform.position);
            Destroy(gameObject);
            Debug.Log("Collected");
        }
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
