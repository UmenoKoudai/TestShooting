using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipBase : MonoBehaviour
{
    [SerializeField, Tooltip("体力")]
    private int _hp = 5;
    [SerializeField, Tooltip("移動速度")]
    private float _moveSpeed = 1.5f;
    [SerializeField, Tooltip("攻撃力")]
    private int _power = 1;
    [SerializeField, Tooltip("弾のPrefab")]
    private GameObject _bullet;
    [SerializeField, Tooltip("弾を出す場所")]
    private Transform _muzzle;
    [SerializeField, Tooltip("弾のインターバル")]
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
