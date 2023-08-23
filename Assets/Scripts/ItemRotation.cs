using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        this.gameObject.transform.localPosition = new Vector3(0, Mathf.Sin(Time.time) * 0.1f + 0.2f, 0);
    }
    
}
