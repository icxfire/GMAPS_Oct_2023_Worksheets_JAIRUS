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

    void FixedUpdate()
    {
        gravityDir = planet.position - transform.position;
        Debug.Log(gravityNorm);
        moveDir = new Vector3(gravityDir.y, -gravityDir.x, 0);
        moveDir = moveDir.normalized * -1f;

        rb.AddForce(moveDir * force, ForceMode2D.Force);
        gravityNorm = gravityDir.normalized;
        if (rb.velocity.y < 0 | rb.velocity.y > 0)
        {
            rb.AddForce(gravityNorm * gravityStrength, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode2D.Force);
        }

        float angle = Vector3.SignedAngle(Vector3.down, gravityDir, Vector3.forward);
        rb.MoveRotation(Quaternion.Euler(0, 0, angle));

        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red);


    }
}


