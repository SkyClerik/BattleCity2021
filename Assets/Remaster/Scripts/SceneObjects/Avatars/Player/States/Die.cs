using UnityEngine;

namespace State
{
    public class Die : IStateBase
    {
        private AvatarData _avatarData;
        public Die(AvatarData avatarData)
        {
            _avatarData = avatarData;
        }

        public void Update()
        {

        }

        public void UpdateState()
        {
            throw new System.NotImplementedException();
        }
    }
}