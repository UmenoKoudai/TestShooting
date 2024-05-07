using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : StateMachine
{
    private ShipBase _player;
    private float _timer;

    public NormalState(ShipBase player)
    {
        _player = player;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        _timer += Time.deltaTime;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        _player.Rb.velocity = new Vector2(x, y) * _player.MoveSpeed;
        if (_timer < _player.Interval) return;
        if (Input.GetButton("Fire1")) _player.Shoot();
        _timer = 0;
    }
}
