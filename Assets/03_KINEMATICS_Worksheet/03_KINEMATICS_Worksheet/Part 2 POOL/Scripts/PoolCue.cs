using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
            if (ball != null && ball.IsCollidingWith(mousePos.x, mousePos.y))
            {
                drawnLine = lineFactory.GetLine(startLinePos, new Vector2(ball.Position.x, ball.Position.y), 10f, Color.red);
                drawnLine.EnableDrawing(true);
            }
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            drawnLine.EnableDrawing(false);
            Vector2 mousePos = Input.mousePosition;
            //update the velocity of the white ball.
            HVector2D v = new HVector2D(mousePos.x - ball.Position.x, mousePos.y - ball.Position.y);
            ball.Velocity = v;
            Debug.Log((mousePos.x - ball.Position.x, mousePos.y - ball.Position.y));
            drawnLine = null; // End line drawing            
        }

                 /* if (drawnLine != null)
                  {
                      drawnLine.end = /*your code here*/; // Update line end
                                                     //}
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    //public void Clear()
    //{
    //    var activeLines = lineFactory.GetActive();

    //    foreach (var line in activeLines)
    //    {
    //        line.gameObject.SetActive(false);
    //    }
    //}
}
