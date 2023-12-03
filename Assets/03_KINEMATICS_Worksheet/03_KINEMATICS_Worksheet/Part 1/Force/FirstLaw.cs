using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Impulse); // adds a force to the ball and pushes it.
     }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

