using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SprintBoots : MonoBehaviour
{
    public Movement playerScript;
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        playerScript = player.GetComponent<Movement>();
        playerScript.pickUpBoots();
        Destroy(gameObject);
    }
}
