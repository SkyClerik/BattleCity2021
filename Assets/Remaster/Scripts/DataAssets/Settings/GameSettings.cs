using UnityEngine;

namespace Data.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField]
        private Team _playerATeam = Team.Players;
        public Team PlayerATeam { get { return _playerATeam; } set { _playerATeam = value; } }

        [SerializeField]
        private Team _playerBTeam = Team.Players;
        public Team PlayerBTeam { get { return _playerBTeam; } set { _playerBTeam = value; } }

        [SerializeField]
        private Team _playerCTeam = Team.Players;
        public Team PlayerCTeam { get { return _playerCTeam; } set { _playerCTeam = value; } }

        [SerializeField]
        private Team _botsTeam = Team.Bots;
        public Team BotsTeam { get { return _botsTeam; } set { _botsTeam = value; } }
    }
}

public enum Team : byte
{
    Players,  // Игроки
    Bots,  // Боты
    Damagable, // Объект на карте который можно повредить
}