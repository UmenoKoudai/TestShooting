using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 1.5f;
    [SerializeField, Range(-1, 1)]
    private int _bulletDirection = 1;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(0, _bulletDirection) * _moveSpeed;
    }
}
