using Extensions;
using UnityEngine;

namespace State
{
    internal class PhaseOne : IStateBase
    {
        private AvatarData _avatarData;
        private float _speed = 1f;
        private Vector3 _half = new Vector3(0.4f, 0.4f, 0.4f);
        private Vector3 _direction = Vector3.zero;
        private Vector3 _destination;
        private Transform _transform;

        public PhaseOne(AvatarData avatarData)
        {
            _avatarData = avatarData;
            _transform = avatarData.transform;
            _direction = Vector3.zero;
        }

        public void Update()
        {
            if (IsSpaceFree() == true && _direction != Vector3.zero)
            {
                //if (_avatarData.MoveAudioSource.isPlaying == false)
                //   _avatarData.MoveAudioSource.Play();

                _destination = _transform.position + _direction;
                float step = _speed * Time.deltaTime;
                _transform.position = Vector3.MoveTowards(_transform.position, _destination, step);
            }
            else
            {
                SetRandomDirection();
                _avatarData.SetRotationFast(_direction);
            }
        }

        public void UpdateState()
        {

        }

        private void SetRandomDirection()
        {
            _direction = Vector3.zero;
            float r = Random.Range(0.0f, 100f);
            if (r < 50)
            {
                _direction.x = Random.Range(-1, 2);
            }
            else
            {
                _direction.z = Random.Range(-1, 2);
            }
        }

        private bool IsSpaceFree()
        {
            if (Physics.BoxCast(_transform.position, _half, _direction, out RaycastHit hit, Quaternion.identity, 0.1f))
            {
                if (hit.collider.TryGetComponent(out Bullet _))
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}