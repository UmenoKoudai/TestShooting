using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ShipBase
{
    public enum PlayerState
    {
        Normal,
        Finish,
    }

    private PlayerState _state = PlayerState.Normal;
    public PlayerState State
    {
        get => _state;
        set
        {
            if (_state == value) return;
            _state = value;
            switch(_state)
            {
                case PlayerState.Normal:
                    _normal.Enter();
                    break;
                case PlayerState.Finish:
                    break;
            }
        }
    }

    private NormalState _normal;
    

    public void Init()
    {
        Rb = GetComponent<Rigidbody2D>();
        _normal = new NormalState(this);
    }

    public void ManualUpdate()
    {
        switch (_state)
        {
            case PlayerState.Normal:
                _normal.Update();
                break;
            case PlayerState.Finish:
                break;
        }
    }

    public void ManualFixedUpodate()
    {

    }

    public override void Shoot()
    {
        Instantiate(Bullet, Muzzle.position, Quaternion.identity);
    }
}
