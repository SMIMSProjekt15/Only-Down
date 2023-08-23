using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    public Vector2 turn;
    public float sensitivityX, sensitivityY = 2;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivityX;
        turn.y = Mathf.Clamp(Input.GetAxis("Mouse Y") * sensitivityY + turn.y, -90, 90);
        player.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        cam.transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
    
    }

    public void SetSensitivity(float pSensitivityX = 2, float pSensitivityY = 2)
    {
        sensitivityX = pSensitivityX;
        sensitivityY = pSensitivityY;
    }
}