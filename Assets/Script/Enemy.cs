using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ShipBase
{
    [Header("デバック用")]
    [SerializeField, Tooltip("デバックするときにオンにする")]
    private bool _debugMode = false;
    [SerializeField, Tooltip("回転の大きさ")]
    private float _radius = 0.5f;
    [SerializeField, Tooltip("X軸の移動スピード")]
    private float _rotateSpeedX = 0.5f;
    [SerializeField, Tooltip("Y軸の移動スピード")]
    private float _rotateSpeedY = 0.5f;
    [SerializeReference]
    [SubclassSelector]
    [SerializeField, Tooltip("動きのパターン")]
    private EnemyMoveBase _moveBase;


    public EnemyMoveBase MovePattern { get; set; }
    public float Radius { get; set; }
    public float RotateX { get; set; }
    public float RotateY {  get; set; }

    public void Init()
    {
        if (_debugMode)
        {
            MovePattern.Radius = _radius;
            MovePattern.RotateX = _rotateSpeedX;
            MovePattern.RotateY = _rotateSpeedY;
            MovePattern = _moveBase;
        }
        else
        {
            MovePattern.Radius = Radius;
            MovePattern.RotateX = RotateX;
            MovePattern.RotateY = RotateY;
        }
        MovePattern.Speed = MoveSpeed;
        MovePattern.Ship = this;
    }

    public void Update()
    {
        MovePattern.Move();
    }
}
