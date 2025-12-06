namespace Player.PlayerAttributes
{
    public class PlayerAttributesManager
    {
        // Referenzen
        private readonly PlayerAttributesSO _playerStats;

        // Player-Attributes
        public static float HorizontalMovementSpeed { get; private set; }
        public static int MaxHealth { get; private set; }

        public PlayerAttributesManager(PlayerAttributesSO playerStats)
        {
            _playerStats = playerStats;
            SetAttributes();
        }

        /// <summary>
        /// Setzt die eigenen Attribut-Werte entsprechend denen aus dem eigenen <see cref="PlayerAttributesSO"/>-ScriptableObject
        /// </summary>
        private void SetAttributes()
        {
            // Resources
            MaxHealth = _playerStats.MaxHealth;
            // Movement
            HorizontalMovementSpeed = _playerStats.HorizontalMovementSpeed;
        }
    }
}
