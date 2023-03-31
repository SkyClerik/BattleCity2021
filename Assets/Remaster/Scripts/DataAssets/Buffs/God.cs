using UnityEngine;

namespace Data.Buff
{
    [CreateAssetMenu(fileName = "Shild", menuName = "Buff/Shild")]
    public class God : BuffBase
    {
        private float _currectTime = 0f;
        private bool _isWait
        {
            get
            {
                _currectTime += Time.deltaTime;

                if (_currectTime >= 1)
                {
                    _currectTime = 0f;
                    return false;
                }

                return true;
            }
        }

        private float _curTime;
        private bool _isDone
        {
            get
            {
                _curTime -= Time.deltaTime;

                if (_curTime <= 0)
                {
                    _curTime = curentRollBack;
                    return true;
                }

                return false;
            }
        }

        private byte value = 100;
        private AvatarData _avatarData;
        private BuffContainer _buffContainer;

        public override void Init(AvatarData avatarData, BuffContainer buffContainer)
        {
            _avatarData = avatarData;
            _buffContainer = buffContainer;
            _curTime = curentRollBack;
            avatarData.MaximumHealPoint += value;
        }

        public override void Stop()
        {
            _avatarData.MaximumHealPoint -= value;
            _avatarData.CurentHealPoint = _avatarData.MaximumHealPoint;
        }

        public override void Update()
        {
            if (_isDone == true)
            {
                _buffContainer.RemoveFrom(this);
                return;
            }

            if (_isWait == true)
                return;

            _avatarData.CurentHealPoint++;
        }
    }
}