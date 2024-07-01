/*
 * Author: Jarene Goh
 * Date: 25 June 2024
 * Description: Script that controls the Door
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : Interactable
{
    [SerializeField]
    private AudioSource openAudio;


    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);

        bool ownMedal = GameManager.instance.OwnMedal();
        int currentScore = GameManager.instance.GetScore();

        if (ownMedal && currentScore >= 20)
        {
            UIChanger.instance.DoorTextFalse();
            OpenDoor();
        }
        else
        {
            Debug.Log("You dont have everything you need to enter the castle!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool ownMedal = GameManager.instance.OwnMedal();

        if (ownMedal == false)
        {
            UIChanger.instance.DoorTextTrue("You need the medal to enter the castle!");
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

    public void OpenDoor()
    {
        // Create a new Vector3 and store the current rotation.
        Vector3 newRotation = transform.eulerAngles;

        // Add 90 degrees to the y axis rotation
        newRotation.y += 90f;

        // Assign the new rotation to the transform
        transform.eulerAngles = newRotation;

        openAudio.Play();
    }

}
