using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ShipBase
{
    [SerializeField, Tooltip("発射する弾の数")]
    private int _bulletCount;
    [SerializeField, Tooltip("発射する弾の上限")]
    private int _maxBullet;
    [SerializeField, Tooltip("連射")]
    private int _rapid;
    [SerializeField, Tooltip("連射回数の上限")]
    private int _maxRapid;

    public int BulletCount 
    {
        get => _bulletCount;
        set
        {
            _bulletCount = value;
            if(_bulletCount > _maxBullet)
            {
                _bulletCount = _maxBullet;
            }
        }
    }

    public int Rapid
    {
        get => _rapid;
        set
        {
            _rapid = value;
            if (_rapid > _maxRapid)
            {
                _rapid = _maxRapid;
            }
        }
    }

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

    public void ManualFixedUpdate()
    {

    }

    public override void Shoot()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            Instantiate(Bullet, Muzzle.position, Quaternion.identity);
        }
    }
}
