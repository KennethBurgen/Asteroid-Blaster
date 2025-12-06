namespace Player.PlayerAttributes
{
    public class PlayerAttributesManager
    {
        // Referenzen
        private readonly PlayerAttributesSO _playerStats;

        // Player-Attributes
        public float HorizontalMovementSpeed { get; private set; }
        public int MaxHealth { get; private set; }

        public PlayerAttributesManager(PlayerAttributesSO playerStats)
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
