using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject youWinText;
    // Start is called before the first frame update
    void Start()//setWinning
    {
        youWinText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            youWinText.SetActive(true);
        }
    }
}
