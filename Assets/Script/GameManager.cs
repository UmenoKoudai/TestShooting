using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Generator _generator;

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

    void Start()
    {
        _player.Init();
        _generator.Init();
    }

    void Update()
    {
        if(_state == GameState.GameMode)
        {
            _player.ManualUpdate();
            _generator.ManualUpdate();
        }
    }

    public void StateChange(GameState change)
    {
        State = change;
    }
}
