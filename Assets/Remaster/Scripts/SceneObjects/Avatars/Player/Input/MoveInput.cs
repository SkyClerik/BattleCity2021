using Extensions;
using UnityEngine;

public class MoveInput : IUpdate
{
    private AvatarData _avatarData;

    private Vector3 _direction;
    private Vector3 _destination;
    private float _speed = 1f;
    private Transform _transform;
    private Vector3 _half = new Vector3(0.4f, 0.4f, 0.4f);

    private byte _playerNum = 0;
    private Belong _belong;
    private float _axisx, _axisz = 0;

    private AudioPool _audioPool;

    public MoveInput(AvatarData avatarData, Belong belong)
    {
        _avatarData = avatarData;
        _transform = avatarData.transform;
        _belong = belong;
        _playerNum = (byte)belong;
        _audioPool = AudioPool.Instance;
    }

    public void Update()
    {
        if (_axisx == 0 && _axisz == 0)
            _audioPool.Stop(_belong);

        if (_playerNum != 0)
        {
            _axisx = Input.GetAxisRaw($"Horizontal{_playerNum}");
            _axisz = Input.GetAxisRaw($"Vertical{_playerNum}");

            if (_axisx != 0 && _axisz != 0)
                return;

            if (_axisx != 0 || _axisz != 0)
                Move();
        }
    }

    private void SetDestination()
    {
        _direction = new Vector3(_axisx, 0, _axisz);
        _destination = _avatarData.transform.position + (_direction);
        //_destination = _avatarData.transform.position + (_direction * 0.5f);
        //_destination.x = Mathf.Round(_destination.x * 10.0f) * 0.1f;
        //_destination.z = Mathf.Round(_destination.z * 10.0f) * 0.1f;
    }

    private void Move()
    {
        _audioPool.Move(_belong, this);

        SetDestination();
        _avatarData.SetRotation(_destination);

        if (IsSpaceFree() == true)
        {
            float step = _speed * Time.deltaTime;
            _transform.position = Vector3.MoveTowards(_transform.position, _destination, step);
        }
    }

    private bool IsSpaceFree()
    {
        if (Physics.BoxCast(_avatarData.transform.position, _half, _direction, out RaycastHit _, Quaternion.identity, 0.1f))
        {
            return false;
        }
        return true;
    }

}