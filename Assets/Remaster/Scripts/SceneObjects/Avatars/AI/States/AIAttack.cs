namespace State
{
    internal class AIAttack : IStateBase
    {
        private AvatarData _avatarData;
        private SkillContainer _skillContainer;

        public AIAttack(AvatarData avatarData)
        {
            _avatarData = avatarData;
            _skillContainer = _avatarData.LinkSkillContainer;
        }

        public void Update()
        {

        }

        public void UpdateState()
        {
            Attacked();
        }

        private void Attacked()
        {
            _skillContainer.TryUseSkill(0);
        }
    }
}