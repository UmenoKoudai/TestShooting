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

    private PlayerState _state;
    public PlayerState State
    {
        get => _state;
        set
        {
            switch(_state)
            {
                case PlayerState.Normal:
                    break;
                case PlayerState.Finish:
                    break;
            }
        }
    }

    public void Init()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    public void ManualUpdate()
    {
        switch (_state)
        {
            case PlayerState.Normal:
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
