using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D playerRigidBody;

        public void MovePlayer(Vector2 movement)
        {
            playerRigidBody.linearVelocity = movement;
        }
    }
}
