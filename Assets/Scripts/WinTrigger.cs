using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public GameObject timer;
    private timer script;
    void Start()
    {
        script = timer.GetComponent<timer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StaticTime.Time = script.FormatTime();
            SceneManager.LoadScene(4);
        }
    }
}
