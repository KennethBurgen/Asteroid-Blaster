using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D playerRigidBody;

        [SerializeField]
        private new Camera camera;

        private readonly float _movementSpeed = 10f;

        private float _leftBound,
            _rightBound;

        void Awake()
        {
            _leftBound = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x + 0.32f;
            _rightBound = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x;
            Debug.Log(_leftBound);
        }

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

            playerRigidBody.AddForce(movement * (_movementSpeed * 10f), ForceMode2D.Force);
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
