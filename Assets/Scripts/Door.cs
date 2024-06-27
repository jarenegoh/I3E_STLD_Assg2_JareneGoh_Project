using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private AudioSource openAudio;

    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);

        bool hasMedal = GameManager.instance.HasMedal();
        int currentScore = GameManager.instance.GetScore();

        if (hasMedal && currentScore >= 5)
        {
            OpenDoor();
        }
        else
        {
            Debug.Log("You dont have everything you need to enter the castle!");
        }
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
