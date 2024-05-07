using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipBase : MonoBehaviour
{
    [SerializeField]
    private int _hp = 5;
    [SerializeField]
    private float _moveSpeed = 1.5f;
    [SerializeField]
    private int _power = 1;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _muzzle;
    [SerializeField]
    private float _interval = 0.5f;

    public int Hp { get => _hp; set => _hp = value; }
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public int Power { get => _power; set => _power = value; }
    public float Interval => _interval;
    public GameObject Bullet => _bullet;
    public Transform Muzzle => _muzzle;
    public Rigidbody2D Rb { get; set; }

    public virtual void Shoot()
    {
        Debug.LogError("オーバーライドしていません");
    }
}
