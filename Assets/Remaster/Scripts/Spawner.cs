using Pool;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    [SerializeField]
    private Transform[] _enemyPoints = new Transform[3];

    [SerializeField]
    private Transform[] _playerPoints = new Transform[2];

    private AvatarData _avatarData = null;
    private void Start()
    {
        GlobalEvents.Instance.OnAvatarDestroy += OnAvatarDestroy;
    }

    private void OnAvatarDestroy(AvatarData avatarData)
    {
        var t = 1f;
        switch (avatarData.CurTeam)
        {
            case Team.Players:
                t = Random.Range(1f, 3f);
                _avatarData = avatarData;
                Invoke(nameof(TrySpawnPlayer), t);
                break;
            case Team.Bots:
                t = Random.Range(1f, 3f);
                Invoke(nameof(TrySpawnEnemy), t);
                break;
            case Team.Damagable:
                break;
        }
    }

    private void TrySpawnEnemy()
    {
        if (GameSettings.Instance.EnemyCount < GameSettings.Instance.MaxEnemyCount)
        {
            var index = Random.Range(0, _enemyPoints.Length);
            SpawnEnemy(index);
        }
    }

    public void SpawnEnemy(int index)
    {
        ObjectPooler.Instance.SpawnFromPool(PoolObjectTag.EnemyDefault, _enemyPoints[index].position, Quaternion.Euler(Vector3.back));
        GameSettings.Instance.EnemyCount++;
    }

    private void TrySpawnPlayer()
    {
        if (GameSettings.Instance.ExtraLives <= 0)
            return;

        // Если в игре максимум игроков
        if (GameSettings.Instance.PlayerCount == GameSettings.Instance.MaxPlayerCount)
            return;

        _avatarData.TryGetComponent(out InputPlayerAvatar inputPlayerAvatar);
        SpawnPlayer(inputPlayerAvatar.BelongPlayer);
    }

    public void SpawnPlayer(Belong belong)
    {
        GameObject avatar = ObjectPooler.Instance.SpawnFromPool(PoolObjectTag.Player, _playerPoints[(byte)belong - 1].position, Quaternion.Euler(Vector3.forward));
        if (avatar.TryGetComponent(out InputPlayerAvatar inputPlayerAvatar))
            inputPlayerAvatar.BelongPlayer = belong;

        GameSettings.Instance.PlayerCount++;
        GameSettings.Instance.ExtraLives--;

        GlobalEvents.Instance.AvatarSpawn(avatar.GetComponent<AvatarData>());
    }
}
