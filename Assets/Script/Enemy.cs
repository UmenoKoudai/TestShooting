using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ShipBase
{
    [SerializeField]
    private float _radian = 0.5f;
    [SerializeField]
    private float _rotateSpeedX = 0.5f;
    [SerializeField]
    private float _rotateSpeedY = 0.5f;
    public EnemyMoveBase MovePattern { get; set; }
    float _a = 1f;
    Vector3 _b;
    Rigidbody2D _rb;



    public void Init()
    {

    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _b = transform.position;
    }
    public void Update()
    {
        float x = Mathf.Cos(Time.time * _rotateSpeedX);
        float y = Mathf.Sin(Time.time * _rotateSpeedY);
        _a -= 0.001f;
        transform.position = new Vector2(_b.x + x * _radian, _b.y + y * _radian + _a);
    }
}
