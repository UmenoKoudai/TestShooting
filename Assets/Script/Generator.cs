using System;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField, Tooltip("エネミーのPrefab")]
    private GameObject _enemyPrefab;
    [SerializeField, Tooltip("インスタンスる範囲")]
    private BoxCollider2D _collider;
    [SerializeField, Tooltip("インスタンスする間隔")]
    private float _interval;
    [SerializeField, Tooltip("一度にインスタンスするエネミーの数")]
    private int _createCount = 1;

    private float _timer;
    private float _colliderX;
    private float _colliderY;

    enum MovePattern
    {
        Circle,
        Curve,
        Straight,
    }

    public void Init()
    {
        _timer = _interval;
        _colliderX = _collider.size.x / 2;
        _colliderY = _collider.size.y / 2;
    }

    public void ManualUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            for (int i = 0; i < _createCount; i++)
            {
                int randomNum = UnityEngine.Random.Range(0, Enum.GetNames(typeof(MovePattern)).Length);
                float x = UnityEngine.Random.Range(-_colliderX, _colliderX);
                float y = UnityEngine.Random.Range(-_colliderY, _colliderY);
                var createArea = new Vector2(transform.position.x + x, transform.position.y + y);
                MovePattern pattern = (MovePattern)Enum.ToObject(typeof(MovePattern), randomNum);
                var script = Instantiate(_enemyPrefab, createArea, Quaternion.identity).GetComponent<Enemy>();
                script.RotateX = UnityEngine.Random.Range(0f, 5f);
                script.RotateY = UnityEngine.Random.Range(0f, 5f);
                script.Radius = UnityEngine.Random.Range(1f, 2.5f);
                switch (pattern)
                {
                    case MovePattern.Circle:
                        script.MovePattern = new CircleMove();
                        break;
                    case MovePattern.Curve:
                        script.MovePattern = new CurveMove();
                        break;
                    case MovePattern.Straight:
                        script.MovePattern = new StraightMove();
                        break;
                }
                script.Init();
            }
            _timer = 0;
        }
    }
}
