using UnityEngine;

namespace Data.Settings
{
    [CreateAssetMenu(fileName = "BulletSettings", menuName = "Settings/Bullet")]
    public class BulletSettings : ScriptableObject
    {
        [SerializeField]
        private bool _ignoreOwner = true;
        public bool IgnoreOwner { get { return _ignoreOwner; } set { _ignoreOwner = value; } }

        [SerializeField]
        private bool _ignoreAllies = true;
        public bool IgnoreAllies { get { return _ignoreAllies; } set { _ignoreAllies = value; } }

        [SerializeField]
        private Team _currentTeam = Team.Players;
        public Team CurrentTeam { get { return _currentTeam; } set { _currentTeam = value; } }
    }
}