using UnityEngine;

public class GameSettings : Singleton<GameSettings>
{
    [SerializeField]
    private int _enemyCount = 0;
    [SerializeField]
    private int _maxEnemyCount = 20;
    [SerializeField]
    private int _playerCount = 0;
    [SerializeField]
    private int _maxPlayerCount = 2;
    [SerializeField]
    private bool _frandlyFire = true;
    [SerializeField]
    private int _extraLives = 3;

    public int EnemyCount { get => _enemyCount; set => _enemyCount = value; }
    public int MaxEnemyCount => _maxEnemyCount;
    public int PlayerCount { get => _playerCount; set => _playerCount = value; }
    public int MaxPlayerCount { get => _maxPlayerCount; set => _maxPlayerCount = value; }
    public bool FrandlyFire => _frandlyFire;
    public int ExtraLives { get => _extraLives; set => _extraLives = value; }
}
