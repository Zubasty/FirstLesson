using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _score;

    public event Action<int> AddedScore;

    private void Awake()
    {
        _score = 0;
    }

    private void OnEnable()
    {
        _player.TookCoin += OnTookCoin;
    }

    private void OnDisable()
    {
        _player.TookCoin -= OnTookCoin;    
    }

    private void OnTookCoin()
    {
        _score++;
        AddedScore?.Invoke(_score);
    }
}
