using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Exit : Interactable
{
    [SerializeField]
    private AudioClip openAudio;

    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);

        bool ownPotion = GameManager.instance.OwnPotion();

        if (ownPotion)
        {
            UIChanger.instance.CongratsBackgroundTrue();
            AudioSource.PlayClipAtPoint(openAudio, transform.position, 0.5f);
        }
        else
        {
            UIChanger.instance.DoorTextTrue("Fix-It-All potion required!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool ownPotion = GameManager.instance.OwnPotion();

        if (ownPotion == false)
        {
            UIChanger.instance.DoorTextTrue("You need the Fix-It-All potion!");
        }
        else
        {
            UIChanger.instance.DoorTextTrue("Hit 'E' to interact!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UIChanger.instance.DoorTextFalse();
    }
}
