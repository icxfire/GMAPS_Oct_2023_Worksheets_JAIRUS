using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();

        if (IsCaptain)
        {
            FindMinimum();
        }
    }

    void FindMinimum()
    {
        List<float> heights = new List<float>();
        for (int i = 0; i < 10; i++)
        {
            float height = Random.Range(5f, 20f);
            heights.Add(height);
        }
        Debug.Log(heights.Min());
    }

    float Magnitude(Vector3 vector)
    {
        return vector.magnitude;
    }

    Vector3 Normalise(Vector3 vector)
    {
        return vector.normalized;
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return Vector3.Dot(vectorA, vectorB);
    }

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;

        for (int i = 0; i < OtherPlayers.Length; i++)
        {
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.position;
            Vector3 normalisedToPlayer = Normalise(toPlayer);

            float dot = Dot(normalisedToPlayer, Normalise(transform.forward));
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

            if (angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];      
            }
        }
        return closest;
    }

    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            Vector3 otherPlayerPos = other.transform.position - transform.position;
            Debug.DrawRay(transform.position, otherPlayerPos, Color.black);
        }
    }

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);
        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

            DrawVectors();

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;

            foreach (SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}


