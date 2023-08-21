using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speedValue;
    public float jumpForce;
    public Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       body.velocity = new Vector3(Input.GetAxis("Horizontal")*speedValue, body.velocity.y, Input.GetAxis("Vertical")*speedValue);
       if(Input.GetButtonDown("Jump"))
       {
            body.velocity = new Vector3(body.velocity.x, jumpForce, body.velocity.z);
       }
    }
}
