/*
 * Author: Jarene Goh
 * Date: 24 June 2024
 * Description: Script that controls the Scene Change
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// The index of the target scene to load.
    /// </summary>
    public int targetSceneIndex;

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The Collider of the object that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(targetSceneIndex);
        }
    }
}
