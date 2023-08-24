using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelCollection : MonoBehaviour
{
    public GameObject pickUpEffect;
    public GameObject counter;
    public GameObject gameObject;
    private JewelCounter script;
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(pickUpEffect, transform.position, transform.rotation);
            script = counter.GetComponent<JewelCounter>();
            script.jewelCount += 1;
            Debug.Log("jewelcount" + script.jewelCount);
            Destroy(gameObject);
        }
    }
}
