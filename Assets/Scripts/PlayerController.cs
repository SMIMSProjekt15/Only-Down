using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{

    [Header("Movement")]
    public float slideSpeed = 40f;
    public float currentSpeed;

    private float desiredMoveSpeed;
    private float lastDesiredMoveSpeed;
    public bool sliding;

    [Header("Slope Handling")]
    public float maxSlopeAngle = 40f;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public float playerHeight;

    
    //public Rigidbody body;
    private Vector3 moveDirection;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    public float sprintSpeed = 6;
    public float speedValue = 3;
    private float speed;
    public float jumpForce = 3;
    public Rigidbody body;
    private int jumpCount = 0;
    private int maxJumps = 1;
    private bool sprintEnabeled = false;
    private bool bootsPickedUp = false;
    public bool onWall = false;


    // Start is called before the first frame update
    void Start()
    {
        speed = speedValue;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        setMoveDirection();
        SpeedControll();
        SetSpeedUsed(); //set wheter to use the slide speed (can increase even --> no limit) or to use normal speed
        
        
        //on slope
        if (OnSlope() && !exitingSlope)
        {
            body.AddForce(GetSlopeMoveDirection(moveDirection) * currentSpeed * 20f, ForceMode.Force);

            if (body.velocity.y > 0)
                body.AddForce(Vector3.down * 80f, ForceMode.Force);
        }
        else
        { 
            body.velocity = transform.TransformDirection(new Vector3(horizontalInput * currentSpeed, body.velocity.y, verticalInput * currentSpeed));
        }
       if(Input.GetButtonDown("Jump")&& jumpCount<maxJumps)
       {
            exitingSlope = true;
            body.velocity = new Vector3(body.velocity.x, body.velocity.y + jumpForce, body.velocity.z);
            jumpCount++;
       }
       if (body.velocity.y == 0)
       {
            jumpCount=0;
            exitingSlope = false;
       }
       
        if (detectOnWall())
        {
            speedValue = 0;
            body.velocity = new Vector3(body.velocity.x,-0.5f,body.velocity.z);
            onWall = true;
        }
        if (!detectOnWall() && speedValue ==0)
        {
            speedValue = speed;
        }
        //turn off gravity while on slope 
        body.useGravity = !OnSlope();
    }

    public void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    public void SetSpeedUsed() {
        if (sliding)
        {

            if (OnSlope() && body.velocity.y < 0.1f)
                desiredMoveSpeed = slideSpeed;
            else
                desiredMoveSpeed = speedValue;
        }
        else
        {
            this.Sprint();
        }
        FlattenSpeedCurve();
    }

    private void FlattenSpeedCurve()
    {
        //check if desiredMoveSpeed has changed drastically
        if(Mathf.Abs(desiredMoveSpeed - lastDesiredMoveSpeed) > 4f && currentSpeed !=0)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothlyLerpMoveSpeed());
        }
        else
        {
            currentSpeed = speedValue;
        }

        lastDesiredMoveSpeed = desiredMoveSpeed;
    }

    //adjust speed (decrease momentum over time)
    private IEnumerator SmoothlyLerpMoveSpeed()
    {
        //smoothly lerp movement Speed to desired value
        float time = 0;
        float difference = Mathf.Abs(desiredMoveSpeed - currentSpeed);
        float startValue = currentSpeed;

        while (time < difference)
        {
            currentSpeed = Mathf.Lerp(startValue, desiredMoveSpeed, time / difference);
            time += Time.deltaTime;
            yield return null;
        }

        currentSpeed = desiredMoveSpeed;
    }

    private void setMoveDirection() {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
    }

    public bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f)) 
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }
    
    public bool detectOnWall()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f)) 
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle > maxSlopeAngle;
        }

        return false;
    }

    public Vector3 GetSlopeMoveDirection(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }

    private void SpeedControll() 
    { 
        //limiting speed on slope
        if(OnSlope() && !exitingSlope)
        {
            if (body.velocity.magnitude > currentSpeed)
                body.velocity = body.velocity.normalized * currentSpeed;
        }
        //limit speed value for all other cases
        else {
            Vector3 flatVel = new Vector3(body.velocity.x, 0f, body.velocity.z);

            //limit velocity if needed
            if(flatVel.magnitude > currentSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * currentSpeed;
                body.velocity = new Vector3(limitedVel.x, body.velocity.y, limitedVel.z);
            }
        }
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