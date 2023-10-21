using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        gravityDir = planet.position - transform.position;
        moveDir = new Vector3(gravityDir.y, -gravityDir.x, 0);
        moveDir = moveDir.normalized * -1f;

        rb.AddForce(moveDir * force, ForceMode2D.Force);
        Vector3 grvaityNorm = gravityDir.normalized;
        rb.AddForce(gravityDir * gravityStrength, ForceMode2D.Force);

        float angle = Vector3.SignedAngle(Vector3.up, gravityDir, Vector3.forward);
        rb.MoveRotation(Quaternion.Euler(0, 0, angle));


    }
}


