using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D playerRigidBody;

        private float _movementSpeed = 6f;
        private Vector2 _movement;

        private Vector2 _movementInputSmoothVelocity;
        private Vector2 _smoothedMovementInput;

        public void Update()
        {
            _movement = InputProvider.Instance.MoveInput;

            SpeedControl();
        }

        public void FixedUpdate()
        {
            MovePlayer();
        }

        public void MovePlayer()
        {
            // Vector2 targetVelocity = new Vector2(horizontal * _movementSpeed, 0);
            // playerRigidBody.linearVelocity = Vector2.Lerp(
            //     playerRigidBody.linearVelocity,
            //     targetVelocity,
            //     20f * Time.fixedDeltaTime
            // );

            if (_movement == Vector2.zero)
            {
                playerRigidBody.linearVelocity = Vector2.zero;
            }

            playerRigidBody.AddForce(_movement * (_movementSpeed * 10f), ForceMode2D.Force);
        }

        private void SpeedControl()
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
