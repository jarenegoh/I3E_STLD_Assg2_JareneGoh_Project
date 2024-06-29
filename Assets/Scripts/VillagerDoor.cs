using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VillagerDoor : Interactable
{
    [SerializeField]
    private AudioSource openAudio;

    public TextMeshProUGUI doorText;
    public GameObject doorBackground;

    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);

        bool ownMedal = GameManager.instance.OwnMedal();
        int currentScore = GameManager.instance.GetScore();

        if (currentScore >= 0)
        {
            OpenDoor();
        }
        else
        {
            Debug.Log("You dont have everything you need to enter the house!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool ownMedal = GameManager.instance.OwnMedal();

        doorText.text = "Hit 'E' to interact!";
        doorBackground.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        doorText.text = null;
        doorBackground.SetActive(false);
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
