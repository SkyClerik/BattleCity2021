using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string _gameSceneName;

    private Rect _area;

    private void Awake()
    {
        _area = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100);
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(_area);

        if (GUILayout.Button($"Start", GUILayout.MinHeight(50)))
        {
            SceneManager.LoadScene(_gameSceneName);
        }
        if (GUILayout.Button($"Exit", GUILayout.MinHeight(50)))
        {
            Application.Quit();
        }

        GUILayout.EndArea();
    }

}
