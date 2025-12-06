using UnityEngine;

namespace Player.PlayerAttributes
{
    public class PlayerAttributesManager
    {
        // Referenzen
        private ScriptableObject _playerStats;

        // PlayerStats
        public float HorizontalMovementSpeed { get; private set; }
        public int MaxHealth { get; private set; }

        public PlayerAttributesManager(ScriptableObject playerStats)
        {
            _playerStats = playerStats;
        }
    }
}
