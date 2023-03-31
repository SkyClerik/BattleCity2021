using System.Collections.Generic;
using UnityEngine;

public class AvatarTest : MonoBehaviour
{
    [SerializeField]
    private Selector _selector;
    [SerializeField]
    private AStarGrid _aStarGrid;
    [SerializeField]
    private float _speed;

    private IState _currentState;

    private void Start()
    {
        _currentState = new AvatarMove(this, _speed, transform, _selector.transform);
    }

    public void SetStateNull()
    {
        _currentState = null;
    }

    private void OnDrawGizmos()
    {
        _currentState?.OnDrawGizmos();
    }

    private void Update()
    {
        _currentState?.Update();
    }
}


public class AvatarMove : IState
{
    private float _speed;
    private List<Vector3> _path;
    private Transform _transform;
    private int currentNode = 0;
    private AvatarTest _avatarTest;
    public AvatarMove(AvatarTest avatar, float speed, Transform start, Transform end)
    {
        _avatarTest = avatar;
        _transform = avatar.transform;
        _speed = speed;
        if (AStarGrid.Instance.GetPath(start, end, out List<Vector3> path))
        {
            _path = path;
        }
        else
        {
            _avatarTest.SetStateNull();
            Debug.Log("Нет возможного маршрута. Нужно придумать другую точку или что то еще");
        }
    }

    public void OnDrawGizmos()
    {
        if (_path != null)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < _path.Count - 1; i++)
            {
                Gizmos.DrawLine(_path[i], _path[i + 1]);
            }
        }
    }

    public void Update()
    {
        if (_path != null)
        {
            float step = _speed * Time.deltaTime;
            _transform.position = Vector3.MoveTowards(_transform.position, _path[currentNode], step);
            var tdist = Vector3.Distance(_transform.position, _path[currentNode]);
            if (tdist < 0.001f)
            {
                if (currentNode != _path.Count - 1)
                {
                    currentNode++;
                }
                else
                {
                    _avatarTest.SetStateNull();
                }
            }
        }
    }
}

public interface IState
{
    void OnDrawGizmos();
    void Update();
}