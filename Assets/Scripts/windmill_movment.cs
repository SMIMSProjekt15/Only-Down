using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windmill_movment : MonoBehaviour
{
    public GameObject windmill;
    public float windmill_speed = 0.5f;
    // Update is called once per frame
    void Update()
    {
        windmill.transform.Rotate(-windmill_speed * Time.deltaTime, 0, 0);
    }
}
