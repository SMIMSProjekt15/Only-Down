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
        Debug.Log(other.gameObject.name);
        if(other.CompareTag("Player"))
        {
            StaticTime.Time = script.FormatTime();
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(4);
        }
    }
}
