using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private bool _enemyOff = false;


    void Start()
    {
        AudioPool.Instance.PlayStartGame();

        if (_enemyOff == false)
        {
            Spawner.Instance.SpawnEnemy(index: 0);
            Spawner.Instance.SpawnEnemy(index: 1);
            Spawner.Instance.SpawnEnemy(index: 2);
        }

        GameSettings.Instance.MaxPlayerCount = 2;
        GameSettings.Instance.ExtraLives = 5;
        Spawner.Instance.SpawnPlayer(belong: Belong.PlayerA);
        Spawner.Instance.SpawnPlayer(belong: Belong.PlayerB);
    }
}
