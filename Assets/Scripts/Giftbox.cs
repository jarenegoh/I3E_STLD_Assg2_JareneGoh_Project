using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giftbox : MonoBehaviour
{
    [SerializeField]
    private GameObject collectibleToSpawn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnCollectible();
            Destroy(gameObject);
        }
    }



    void SpawnCollectible()
    {
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
    }
}
