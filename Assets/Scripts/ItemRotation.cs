using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float amplitude = 0.003f;
    private Vector3 position;

    // Update is called once per frame
    void Update()
    {
        position = this.gameObject.transform.localPosition;
        this.gameObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        this.gameObject.transform.localPosition = new Vector3(position.x, position.y + Mathf.Sin(Time.time) * amplitude, position.z);
    }
    
}


