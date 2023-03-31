using UnityEngine;

namespace Data.Skill
{
    [CreateAssetMenu(fileName = "DubleSpeed", menuName = "Skill/DubleSpeed")]
    public class DubleSpeed : SkillBase
    {
        [SerializeField]
        public byte _speedMultipier;
        public byte SpeedMultipier
        {
            get { return _speedMultipier; }
            set { _speedMultipier = value; }
        }
        [SerializeField]
        private BuffBase buff;

        public override void Init(AvatarData attacker)
        {
            if (buff != null)
                attacker.LinkBuffContainer.Add(buff, attacker);

            isReadyToUse = false;
        }

        public override void Stop()
        {
            CurentRollBack = rollBackTime;
            isReadyToUse = true;
        }
    }
}