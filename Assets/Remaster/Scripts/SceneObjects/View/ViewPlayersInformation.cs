using UnityEngine;

public class ViewPlayersInformation : MonoBehaviour
{
    private Rect _areaRect;

    private int _extraLive = 0;

    private void Awake()
    {
        _areaRect = new Rect(Screen.width - 300, Screen.height - 300, 300, 300);
        _extraLive = GameSettings.Instance.ExtraLives;

        GlobalEvents.Instance.OnAvatarSpawn += OnAvatarSpawn;
    }

    private void OnAvatarSpawn(AvatarData avatarData)
    {
        if (avatarData.CurTeam == Team.Players)
            _extraLive = GameSettings.Instance.ExtraLives;
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(_areaRect);

        GUILayout.Box($"Player live: {_extraLive}");

        GUILayout.EndArea();
    }
}
