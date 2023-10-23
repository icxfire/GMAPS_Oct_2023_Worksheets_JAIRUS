using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);  
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);

        moveDir.Normalize();
        moveDir = moveDir * -1f;

        rb.AddForce(moveDir.ToUnityVector2() * force, ForceMode2D.Force);

        gravityDir.Normalize();
        gravityNorm = gravityDir;

        if (rb.velocity.y < 0 | rb.velocity.y > 0)
        {
            rb.AddForce(gravityNorm.ToUnityVector2() * gravityStrength, ForceMode2D.Force);
        }
        else
        {
            HVector2D a = new HVector2D(0, 10);
            rb.AddForce(a.ToUnityVector2(), ForceMode2D.Force);
        }

        float angle = Vector3.SignedAngle(Vector3.down, gravityDir.ToUnityVector3(), Vector3.forward);
        rb.MoveRotation(Quaternion.Euler(0, 0, angle));

        DebugExtension.DebugArrow(transform.position, gravityDir.ToUnityVector3(), Color.red);
    }
}
