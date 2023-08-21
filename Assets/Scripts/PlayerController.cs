using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speedValue;
    public float jumpForce;
    public Rigidbody body;
    private int dontInfinetJump = 2;
    private bool resetJumps = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       body.velocity = new Vector3(Input.GetAxis("Horizontal")*speedValue, body.velocity.y, Input.GetAxis("Vertical")*speedValue);
       if(Input.GetButtonDown("Jump")&& dontInfinetJump>0)
       {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y + jumpForce, body.velocity.z);
            dontInfinetJump = dontInfinetJump -1;
       }
       if (body.velocity.y<0)
       {
            resetJumps = true;
       }
       if (body.velocity.y == 0 && resetJumps == true)
       {
        dontInfinetJump = 2;
        resetJumps = false;
       }
    }
}
