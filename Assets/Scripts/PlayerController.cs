using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speedValue;
    public float jumpForce;
    public Rigidbody body;
    private int dontInfinetJump = 2;
    public Sliding characterSlide;
    public KeyCode SlideButton= KeyCode.LeftControl;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for slide input
        if (Input.GetKeyDown(SlideButton))
        {
            characterSlide.wantToSlide = true;
        }

        if (Input.GetKeyUp(SlideButton))
        {
            characterSlide.wantToSlide = false;
        }
        body.velocity = new Vector3(Input.GetAxis("Horizontal")*speedValue, body.velocity.y, Input.GetAxis("Vertical")*speedValue);
       if(Input.GetButtonDown("Jump")&& dontInfinetJump>0)
       {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y + jumpForce, body.velocity.z);
            dontInfinetJump = dontInfinetJump -1;
       }
       if (body.velocity.y == 0)
       {
        dontInfinetJump = 2;
       }
    }
}
