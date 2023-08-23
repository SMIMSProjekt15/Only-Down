using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRespawn : MonoBehaviour
{
    public GameObject spawner;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = spawner.transform.position;
        }
    }
}
