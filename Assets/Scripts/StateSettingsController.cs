using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSettingsController : MonoBehaviour
{
    public static float sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSensitivity(float pSensitivity)
    {
        sensitivity = pSensitivity;
        Debug.Log(sensitivity);
    }
}
