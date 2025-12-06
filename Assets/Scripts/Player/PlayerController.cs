using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D playerRigidBody;

        private readonly float _movementSpeed = 10f;

        /// <summary>
        /// Bewegt den Spieler horizontal innerhalb der Kamera-Grenzen
        /// </summary>
        /// <param name="movement">die Bewegungsrichtung als <see cref="Vector2"/></param>
        public void MovePlayer(Vector2 movement)
        {
            // Bewegung auf nur horizontal beschränken
            movement = new Vector2(movement.x, 0);

            if (movement == Vector2.zero)
            {
                playerRigidBody.linearVelocity = Vector2.zero;
            }
            else
            {
                //playerRigidBody.AddForce(movement * (_movementSpeed * 10f), ForceMode2D.Force);
                Vector2 targetVelocity = new Vector2(movement.x * _movementSpeed, 0);
                playerRigidBody.linearVelocity = Vector2.Lerp(
                    playerRigidBody.linearVelocity,
                    targetVelocity,
                    20f * Time.fixedDeltaTime
                );
            }
        }

        /// <summary>
        /// Verhindert das sich der Spieler schneller als die <see cref="_movementSpeed">maximale Geschwindigkeit</see> bewegt
        /// </summary>
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
