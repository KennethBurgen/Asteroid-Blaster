using Player.Interfaces;
using Player.PlayerAttributes;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        // Serializable Referenzen
        [SerializeField]
        private Rigidbody2D playerRigidBody;

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
                Vector2 targetVelocity = new Vector2(
                    movement.x * PlayerAttributesManager.HorizontalMovementSpeed,
                    0
                );
                playerRigidBody.linearVelocity = Vector2.Lerp(
                    playerRigidBody.linearVelocity,
                    targetVelocity,
                    20f * Time.fixedDeltaTime
                );
            }
        }

        /// <summary>
        /// Verhindert das sich der Spieler schneller als die <see cref="PlayerAttributesManager.HorizontalMovementSpeed">maximale horizontale Geschwindigkeit</see> bewegt
        /// </summary>
        public void HorizontalSpeedControl()
        {
            Vector2 flatVel = new Vector2(playerRigidBody.linearVelocity.x, 0);

            if (flatVel.magnitude > PlayerAttributesManager.HorizontalMovementSpeed)
            {
                Vector2 limitedVel =
                    flatVel.normalized * PlayerAttributesManager.HorizontalMovementSpeed;
                playerRigidBody.linearVelocity = new Vector2(limitedVel.x, 0);
            }
        }
    }
}
