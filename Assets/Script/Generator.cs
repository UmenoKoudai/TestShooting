using System;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField, Tooltip("�G�l�~�[��Prefab")]
    private GameObject _enemyPrefab;
    [SerializeField, Tooltip("�G�l�~�[���o���ꏊ")]
    private Transform _createPos;
    [SerializeField, Tooltip("�C���X�^���X����Ԋu")]
    private float _interval;
    [SerializeField, Tooltip("��x�ɃC���X�^���X����G�l�~�[�̐�")]
    private int _createCount = 1;


    private MovePattern _pattern = MovePattern.Straight;
    private int _randomNum = 0;
    float _timer;

    enum MovePattern
    {
        Circle,
        Curve,
        Straight,
    }

    public void Init()
    {

    }

    public void ManualUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            for (int i = 0; i < _createCount; i++)
            {
                _randomNum = UnityEngine.Random.Range(0, Enum.GetNames(typeof(MovePattern)).Length);
                _pattern = (MovePattern)Enum.ToObject(typeof(MovePattern), _randomNum);
                var enemy = GameObject.Instantiate(_enemyPrefab, _createPos.position, Quaternion.identity);
                var script = enemy.GetComponent<Enemy>();
                script.RotateX = UnityEngine.Random.Range(0f, 5f);
                script.RotateY = UnityEngine.Random.Range(0f, 5f);
                script.Radius = UnityEngine.Random.Range(0f, 5f);
                switch (_pattern)
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
