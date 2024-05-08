using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMove : EnemyMoveBase
{
    public float Speed { get; set; }
    public float Radius { get; set; }
    public float RotateX { get; set; }
    public float RotateY { get; set; }
    public ShipBase Ship { get; set; }

    private float _moveX;


    public StraightMove()
    {

    }

    public void Move()
    {
        Ship.transform.position = new Vector2(Ship.transform.position.x, Ship.transform.position.y - 0.0001f);
    }
}
