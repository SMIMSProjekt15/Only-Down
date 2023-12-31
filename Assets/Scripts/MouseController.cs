using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    public Transform orientation;
    public Vector2 turn;
    public float sensitivityX, sensitivityY = 2;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ChangeSensitivity(SettingsMenu.sensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivityX;
        turn.y = Mathf.Clamp(Input.GetAxis("Mouse Y") * sensitivityY + turn.y, -90, 90);
        player.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        cam.transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        orientation.rotation = Quaternion.Euler(0, turn.x, 0);
    
    }

    public void ChangeSensitivity(float pSensitivity = 2)
    {
        sensitivityX = pSensitivity;
        sensitivityY = pSensitivity;
    }
}