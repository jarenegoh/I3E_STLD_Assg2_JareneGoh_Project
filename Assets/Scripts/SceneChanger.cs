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
    public int targetSceneIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(targetSceneIndex);
        }
    }
}
