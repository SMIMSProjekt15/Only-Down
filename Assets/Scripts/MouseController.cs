using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Vector2 turn;
    public float multiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        multiplier = SettingsMenu.sensitivity;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * multiplier;
        turn.y += Input.GetAxis("Mouse Y") * multiplier;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }

    public void ChangeMultiplier(float pMultiplier)
    {
        multiplier = pMultiplier;
    }
}
