using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlatform : MonoBehaviour
{
    public float damagePerSecond = 10f; // Damage amount per second

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player on damage platform.");
            GameManager.instance.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}
