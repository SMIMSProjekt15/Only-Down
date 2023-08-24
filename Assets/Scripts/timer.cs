using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public float currentTime = 0;
    //public bool timeIsRunning = true;
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        //timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime +=  Time.deltaTime;
        DisplayTime();
    }
    void DisplayTime()
    {
        timeText.text = FormatTime();
    }
    public string FormatTime()
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        return string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
