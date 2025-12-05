using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D playerRigidBody;

        private float _movementSpeed = 10f;

        public void MovePlayer(Vector2 movement)
        {
            // Bewegung auf nur horizontal beschränken
            movement = new Vector2(movement.x, 0);

            if (movement == Vector2.zero)
            {
                playerRigidBody.linearVelocity = Vector2.zero;
            }

            playerRigidBody.AddForce(movement * (_movementSpeed * 10f), ForceMode2D.Force);
        }

        public void SpeedControl()
        {
            Vector2 flatVel = new Vector2(
                playerRigidBody.linearVelocity.x,
                playerRigidBody.linearVelocity.y
            );

            if (flatVel.magnitude > _movementSpeed)
            {
                Vector2 limitedVel = flatVel.normalized * _movementSpeed;
                playerRigidBody.linearVelocity = new Vector2(limitedVel.x, limitedVel.y);
            }
        }
    }
}
