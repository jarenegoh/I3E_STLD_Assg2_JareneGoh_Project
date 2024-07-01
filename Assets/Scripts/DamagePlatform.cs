/*
 * Author: Jarene Goh
 * Date: 30 June 2024
 * Description: Script that controls the platform that damages the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlatform : MonoBehaviour
{
    /// <summary>
    /// The amount of damage inflicted per second.
    /// </summary>
    public float damagePerSecond = 10f; // Damage amount per second

    /// <summary>
    /// Called every frame while a Collider is touching this trigger collider (continuous collision).
    /// Damages the player if they are on the platform.
    /// </summary>
    /// <param name="other">The Collider of the object that is colliding with this platform.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player on damage platform.");
            // Calculate damage based on damage per second and frame time
            GameManager.instance.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}
