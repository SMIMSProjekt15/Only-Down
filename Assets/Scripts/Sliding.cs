using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerObj;
    private Rigidbody rb;
    private Movement pm;

    [Header("Sliding")]
    public float maxSlideTime;
    public float slideForce;

    public float slideYScale;
    private float startYScale;

    [Header("Input")]
    public KeyCode slideKey = KeyCode.LeftControl;
    private float horizontalInput;
    private float verticalInpt;

    private bool sliding;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerController>;

        startYScale = playerObj.localScale.y;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInpt = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInpt != 0))
            StartSlide();

        if (Input.GetKeyUp(slideKey) && sliding)
        {
            StopSlide();   
        }
    }

    private void FixedUpdate()
    {
        if (sliding)
            SlidingMovement();
    }

    private void StartSlide()
    {
        sliding = true;
        playerObj.localScale = new Vector3(playerObj.localScale.x, slideYScale, playerObj.localScale.z);
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

        slideTimer = maxSlideTime;
    }

    private void SlidingMovement()
    {
        .Vector3 inputDirection = orientation.forward * verticalInpt + orientation.right * horiontalInput;

        rb.AddForce(inputDirection.normalized * slideForce, ForceMode.Force);

        slideTimer -= Time.deltaTime;

        if (slideTimer <= 0)
            StopSlide();
    }

    private void StopSlide()
    {
        sliding = false;

        playerObj.localScale = new Vector3(playerObj.localScale.x, startYScale, playerObj.localScale.z) ;
    }
}
/*using UnityEngine;

public class Sliding : MonoBehaviour
{
    public float slideAngleThreshold = 45f; // Angle at which sliding starts
    public float slideSpeed = 5.0f; // Speed of sliding
    public float slideFriction = 0.2f; // Friction to apply while sliding
    public bool wantToSlide = false;

    private CharacterController characterController;
    private bool isSliding = false;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the character is on the ground
        if (characterController.isGrounded)
        {
            // Check the angle of the ground
            float groundAngle = Vector3.Angle(Vector3.up, characterController.velocity.normalized);

            if (groundAngle > 0f && groundAngle <= slideAngleThreshold)
            {
                if (!isSliding)
                {
                    StartSliding();
                }
            }
            else
            {
                if (isSliding)
                {
                    StopSliding();
                }
            }
        }
        else
        {
            if (isSliding)
            {
                StopSliding();
            }
        }

        if (isSliding)
        {/*
            // Apply sliding motion
            Vector3 slideDirection = Vector3.Cross(characterController.velocity.normalized, Vector3.up);
            Vector3 moveDirection = slideDirection * slideSpeed * Time.deltaTime;
            characterController.Move(moveDirection);

            // Apply friction to gradually stop sliding
            characterController.Move(-characterController.velocity * slideFriction * Time.deltaTime);
            
            // Apply sliding motion and friction
            Vector3 slideDirection = Vector3.Cross(characterController.velocity.normalized, Vector3.up);
            Vector3 moveDirection = slideDirection * slideSpeed * Time.deltaTime;
            characterController.Move(moveDirection);

            // Apply friction to gradually stop sliding
            Vector3 friction = -characterController.velocity * slideFriction * Time.deltaTime;
            characterController.Move(friction);
            


        }
    }

    private void StartSliding()
    {
        isSliding = true;
        // You can add animation or effects here
    }

    private void StopSliding()
    {
        isSliding = false;
        // You can add animation or effects here
    }*/
}

