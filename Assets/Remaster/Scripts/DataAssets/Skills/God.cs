using UnityEngine;

namespace Data.Skill
{
    [CreateAssetMenu(fileName = "God", menuName = "Skill/God")]
    public class God : SkillBase
    {
        public override void Init(AvatarData attacker)
        {
            attacker.CurentHealPoint = int.MaxValue;
            isReadyToUse = false;
        }

        public override void Stop()
        {
            CurentRollBack = rollBackTime;
            isReadyToUse = true;
        }
    }
}