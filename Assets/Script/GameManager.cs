using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public class ScoreData
    {
        public ScoreData(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; set; }
        public int Score { get; set; }
    }

    [SerializeField]
    private Player _player;
    [SerializeField]
    private Generator _generator;

    private ScoreData _scoreDate;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    private GameState _state;
    public GameState State 
    {
        get => _state;
        set => _state = value;
    }

    public enum GameState
    {
        GameMode,
        ResultMode,
    }

    private void Awake()
    {
        if(FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            _scoreDate = new ScoreData("ƒoƒ“ƒ^ƒ“‘¾˜Y", 0);
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        if(_player != null)_player.Init();
        if(_generator != null) _generator.Init();
    }

    void Update()
    {
        if(_state == GameState.GameMode)
        {
            if (_player != null) _player.ManualUpdate();
            if (_generator != null) _generator.ManualUpdate();
        }
    }

    public void StateChange(GameState change)
    {
        State = change;
    }

    public void AddScore(int getScore)
    {
        _scoreDate.Score += getScore;
    }
}
