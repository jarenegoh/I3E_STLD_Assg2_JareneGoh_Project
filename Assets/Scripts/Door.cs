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
    /// <summary>
    /// The audio source that plays when the door is opened.
    /// </summary>
    [SerializeField]
    private AudioSource openAudio;

    /// <summary>
    /// Called when the player interacts with the door. Checks if the player has the medal and the required score to open the door.
    /// </summary>
    /// <param name="thePlayer">The player who interacted with the door.</param>
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
            Debug.Log("You don't have everything you need to enter the castle!");
        }
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The Collider of the object that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        bool ownMedal = GameManager.instance.OwnMedal();

        if (!ownMedal)
        {
            UIChanger.instance.DoorTextTrue("You need the medal to enter the castle!");
        }
        else
        {
            UIChanger.instance.DoorTextTrue("Hit 'E' to interact!");
        }
    }

    /// <summary>
    /// Called when another collider exits the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The Collider of the object that exited the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        UIChanger.instance.DoorTextFalse();
    }

    /// <summary>
    /// Opens the door by rotating it 90 degrees on the y-axis and plays the open door sound.
    /// </summary>
    public void OpenDoor()
    {
        // Create a new Vector3 and store the current rotation.
        Vector3 newRotation = transform.eulerAngles;

        // Add 90 degrees to the y-axis rotation
        newRotation.y += 90f;

        // Assign the new rotation to the transform
        transform.eulerAngles = newRotation;

        // Play the door open sound
        openAudio.Play();
    }
}
