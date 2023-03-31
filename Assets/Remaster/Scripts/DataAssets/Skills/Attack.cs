using Pool;
using UnityEngine;

namespace Data.Skill
{
    [CreateAssetMenu(fileName = "Attack", menuName = "Skill/Attack")]
    public class Attack : SkillBase
    {
        [SerializeField]
        private int _damage = 1;
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        [SerializeField]
        private Bullet _bulletPrefab;

        public override void Init(AvatarData attacker)
        {
            attacker.LinkActionOnTheAvatar.PlayAttackEffect();
            GameObject go = ObjectPooler.Instance.SpawnFromPool(PoolObjectTag.BulletDefault, attacker.LinkEffectsContainer.Attack.transform.position, attacker.transform.rotation);
            //GameObject go = Instantiate(_bulletPrefab.gameObject, attacker.LinkEffectsContainer.Attack.transform.position, attacker.transform.rotation);
            go.GetComponent<Bullet>().Init(attacker);
            isReadyToUse = false;
        }

        public override void Stop()
        {
            CurentRollBack = rollBackTime;
            isReadyToUse = true;
        }
    }
}