using System.Collections.Generic;
using UnityEngine;

public class ViewEnemyInformation : MonoBehaviour
{
    private Rect _areaRect;
    private List<Rect> enemyBoxRect;
    private float _boxSize = 20f;

    private void Awake()
    {
        _areaRect = new Rect(0, 0, 300, Screen.height);

        var remainingEnemy = GameSettings.Instance.MaxEnemyCount;
        enemyBoxRect = new List<Rect>();
        for (int i = 0, x = 0, y = 0; i < remainingEnemy; i++)
        {
            enemyBoxRect.Add(new Rect(x * _boxSize, y * _boxSize, _boxSize, _boxSize));

            x = x == 1 ? 0 : 1;
            y += x == 1 ? 0 : 1;
        }

        GlobalEvents.Instance.OnAvatarDestroy += AvatarDestroy;
    }

    private void AvatarDestroy(AvatarData avatarData)
    {
        if (avatarData.CurTeam == Team.Bots)
            enemyBoxRect.RemoveAt(enemyBoxRect.Count - 1);
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(_areaRect);

        for (int i = 0; i < enemyBoxRect.Count; i++)
        {
            GUI.Box(enemyBoxRect[i], string.Empty);
        }

        GUILayout.EndArea();
    }
}
