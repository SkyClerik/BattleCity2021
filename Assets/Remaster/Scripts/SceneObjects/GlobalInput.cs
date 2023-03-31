using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene($"MainMenu");
        }
    }
}
