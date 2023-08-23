using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float sprintSpeed = 6;
    public float speedValue = 3;
    private float speed;
    public float jumpForce = 3;
    public Rigidbody body;
    private int jumpCount = 0;
    private int maxJumps = 1;
    private bool sprintEnabeled = false;
    private bool bootsPickedUp = false;


    // Start is called before the first frame update
    void Start()
    {
        speed = speedValue;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       body.velocity = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal")*speedValue, body.velocity.y, Input.GetAxis("Vertical")*speedValue));
       if(Input.GetButtonDown("Jump")&& jumpCount < maxJumps)
       {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y + jumpForce, body.velocity.z);
            jumpCount++;
       }
       if (body.velocity.y == 0)
       {
        jumpCount=0;
       }
       this.Sprint();
    }
    public void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&&sprintEnabeled==true&&bootsPickedUp==true)
       {
            speedValue = sprintSpeed;
            sprintEnabeled = false;
       }
       else
            if(Input.GetKeyDown(KeyCode.LeftShift)&&sprintEnabeled==false&&bootsPickedUp==true)
       {
            sprintEnabeled = true;
            speedValue = speed;
       }
    }
    public void pickUpBoots()
    {
        bootsPickedUp = true;
        sprintEnabeled = true;
    }

    public void pickUpJetPack()
    {
          maxJumps = 2;
    }
}