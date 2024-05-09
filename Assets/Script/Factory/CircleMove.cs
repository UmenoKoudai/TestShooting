using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : EnemyMoveBase
{
    public float Speed { get; set; }
    public float Radius { get; set; }
    public float RotateX { get; set; }
    public float RotateY { get; set; }
    public ShipBase Ship { get; set; }

    private Vector3 _basePos;

    public CircleMove()
    {
        _basePos = Ship.transform.position;
    }

    public void Move()
    {
        float x = Mathf.Cos(Time.time * RotateX);
        float y = Mathf.Sin(Time.time * RotateY);
        Ship.transform.position = new Vector2(_basePos.x + x * Radius, _basePos.y + y * Radius - 0.001f);
    }
}
