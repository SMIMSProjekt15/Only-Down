using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SprintBoots : MonoBehaviour
{
    private Movement playerScript;
    public GameObject pickUpEffect;
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        Instantiate(pickUpEffect, transform.position, transform.rotation);
        playerScript = player.GetComponent<Movement>();
        playerScript.pickUpBoots();
        Destroy(gameObject);
    }
}
