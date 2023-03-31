using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private bool _enemyOff = false;

    private void Start()
    {
        if (_enemyOff == false)
        {
            Spawner.Instance.SpawnEnemy(index: 0);
            Spawner.Instance.SpawnEnemy(index: 1);
            Spawner.Instance.SpawnEnemy(index: 2);
        }
    }
}
