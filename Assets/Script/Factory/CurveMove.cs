using UnityEngine;

public class CurveMove : EnemyMoveBase
{
    public float Speed { get; set; }
    public float Radius { get; set; }
    public float RotateX { get; set; }
    public float RotateY { get; set; }
    public ShipBase Ship { get; set; }

    private Vector3 _basePos;

    public void Init()
    {
        _basePos = Ship.transform.position;
    }

    public void Move()
    {
        float x = Mathf.Cos(Time.time * RotateX);
        float y = Mathf.Sin(Time.time * RotateY);
        //Ship.transform.position = new Vector2(_basePos.x + x * Radius, _basePos.y -= 0.001f);
        Ship.Rb.velocity = new Vector2(_basePos.x + x * Radius, _basePos.y) * -1;
        Ship.Rb.velocity *= new Vector2(1, Speed);
    }
}
