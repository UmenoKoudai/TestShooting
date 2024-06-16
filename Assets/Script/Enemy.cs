using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ShipBase
{
    [Header("�f�o�b�N�p")]
    [SerializeField, Tooltip("�f�o�b�N����Ƃ��ɃI���ɂ���")]
    private bool _debugMode = false;
    [SerializeField, Tooltip("��]�̑傫��")]
    private float _radius = 0.5f;
    [SerializeField, Tooltip("X���̈ړ��X�s�[�h")]
    private float _rotateSpeedX = 0.5f;
    [SerializeField, Tooltip("Y���̈ړ��X�s�[�h")]
    private float _rotateSpeedY = 0.5f;
    [SerializeReference]
    [SubclassSelector]
    [SerializeField, Tooltip("�����̃p�^�[��")]
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
