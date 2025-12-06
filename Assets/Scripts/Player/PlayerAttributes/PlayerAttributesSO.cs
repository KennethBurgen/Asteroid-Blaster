using Sirenix.OdinInspector;
using UnityEngine;

namespace Player.PlayerAttributes
{
    [CreateAssetMenu(
        fileName = "PlayerAttributes",
        menuName = "Scriptable Objects/PlayerAttributes"
    )]
    public class PlayerAttributesSO : ScriptableObject
    {
        [Title("Resources")]
        [ProgressBar(0, 9, 0, 1, 0, Segmented = true)]
        public int MaxHealth = 3;

        [Title("Movement")]
        [ProgressBar(0, 10, Segmented = true)]
        public float HorizontalMovementSpeed = 8;
    }
}
