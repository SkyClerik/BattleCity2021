public delegate void AvatarDataHandler(AvatarData avatarData);

public class GlobalEvents : Singleton<GlobalEvents>
{
    public event AvatarDataHandler OnAvatarDestroy;
    public event AvatarDataHandler OnAvatarSpawn;
    // Разрушен штаб
    // Взят бонус

    public void AvatarDestroy(AvatarData avatarData)
    {
        switch (avatarData.CurTeam)
        {
            case Team.Players:
                GameSettings.Instance.PlayerCount--;
                break;
            case Team.Bots:
                GameSettings.Instance.EnemyCount--;
                break;
            case Team.Damagable:
                break;
        }

        OnAvatarDestroy?.Invoke(avatarData);
    }

    public void AvatarSpawn(AvatarData avatarData)
    {
        OnAvatarSpawn?.Invoke(avatarData);
    }
}
