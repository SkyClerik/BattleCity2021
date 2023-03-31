using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : Singleton<GameState>
{
    void Start()
    {
        GlobalEvents.Instance.OnAvatarDestroy += AvatarDestroy;
    }

    private void AvatarDestroy(AvatarData avatarData)
    {
        if (avatarData.CurTeam == Team.Players)
        {
            if (GameSettings.Instance.ExtraLives == 0)
            {
                if (GameSettings.Instance.PlayerCount == 0)
                {
                    ThisGameOver();
                }
            }
        }
    }

    public void ThisGameOver()
    {
        Debug.Log("Game Over");
        AudioPool.Instance.PlayGameOver();
        Invoke(nameof(Restart), 3f);
    }

    public void ThisGameWin()
    {
        Debug.Log("Game Win");
    }

    private void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
