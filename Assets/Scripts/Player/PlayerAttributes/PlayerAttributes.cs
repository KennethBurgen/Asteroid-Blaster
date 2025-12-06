using UnityEngine;

namespace Player.PlayerAttributes
{
    [CreateAssetMenu(
        fileName = "PlayerAttributes",
        menuName = "Scriptable Objects/PlayerAttributes"
    )]
    public class PlayerAttributes : ScriptableObject
    {
        [field: Header("Resources")]
        [field: SerializeField]
        public int MaxHealth { get; private set; }

        [field: Header("Movement")]
        [field: SerializeField]
        public float HorizontalMovementSpeed { get; private set; }
    }
}
