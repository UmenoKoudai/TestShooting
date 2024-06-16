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

    private bool _isMoveStart = false;


    public EnemyMoveBase MovePattern { get; set; }
    public float Radius { get; set; }
    public float RotateX { get; set; }
    public float RotateY {  get; set; }

    public void Init()
    {
        MovePattern.Radius = Radius;
        MovePattern.RotateX = RotateX;
        MovePattern.RotateY = RotateY;
        Rb = GetComponent<Rigidbody2D>();
        MovePattern.Speed = MoveSpeed;
        MovePattern.Ship = this;
        MovePattern.Init();
        _isMoveStart = true;
        Debug.Log($"{this.name}:{MovePattern}");
        Debug.Log($"{this.name}:{MovePattern.Speed}");
    }

    private void Start()
    {
        if (_debugMode) 
        {
            MovePattern = _moveBase;
            MovePattern.Radius = _radius;
            MovePattern.RotateX = _rotateSpeedX;
            MovePattern.RotateY = _rotateSpeedY;
            MovePattern = _moveBase;
            Rb = GetComponent<Rigidbody2D>();
            MovePattern.Speed = MoveSpeed;
            MovePattern.Ship = this;
            MovePattern.Init();
            _isMoveStart = true;
        }
    }

    public void Update()
    {
        if (_isMoveStart)
        {
            MovePattern.Move();
        }
    }
}
