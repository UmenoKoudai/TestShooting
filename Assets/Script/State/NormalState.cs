using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : StateMachine
{
    ShipBase _player;

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
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        _player.Rb.velocity = new Vector2(x, y) * _player.MoveSpeed;
        if (Input.GetButtonDown("Fire1")) _player.Shoot();
    }
}
