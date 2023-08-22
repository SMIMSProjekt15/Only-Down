using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerObj;
    private Rigidbody rb;
    private PlayerController pm;

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

    private void StartSlide()
    {

    }

    private void SlidingMovment()
    {
        ...
    }
}
