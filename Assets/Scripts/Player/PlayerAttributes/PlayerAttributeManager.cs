namespace Player.PlayerAttributes
{
    public class PlayerAttributesManager
    {
        // Referenzen
        private readonly PlayerAttributes _playerStats;

        // PlayerStats
        public float HorizontalMovementSpeed { get; private set; }
        public int MaxHealth { get; private set; }

        public PlayerAttributesManager(PlayerAttributes playerStats)
        {
            _playerStats = playerStats;
            SetAttributes();
        }

        private void SetAttributes()
        {
            // Resources
            MaxHealth = _playerStats.MaxHealth;
            // Movement
            HorizontalMovementSpeed = _playerStats.HorizontalMovementSpeed;
        }
    }
}
