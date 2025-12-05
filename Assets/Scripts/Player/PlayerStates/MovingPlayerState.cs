using UnityEngine;
using Utilities;
using Utilities.StateMachineSystem.Interfaces;

namespace Player.PlayerStates
{
    public class MovingPlayerState : IFixedUpdatableState
    {
        private readonly PlayerManager _playerManager;
        private readonly PlayerController _playerController;

        private Vector2 _movement;

        public MovingPlayerState(PlayerManager playerManager, PlayerController playerController)
        {
            _playerManager = playerManager;
            _playerController = playerController;
        }

        public void OnEnter()
        {
            Debug.Log("Entered MovingPlayerState");
        }

        public void OnExit()
        {
            // to be done
            Debug.Log("Exited MovingPlayerState");
        }

        public void OnUpdate()
        {
            // to be done
            _movement = InputProvider.Instance.MoveInput;

            _playerController.SpeedControl();
        }

        public void OnFixedUpdate()
        {
            _playerController.MovePlayer(_movement);

            CheckTransition();
        }

        /// <summary>
        /// Prüft die Bedingungen ob zu einem anderen möglichen PlayerState gewechselt werden kann
        /// </summary>
        public void CheckTransition()
        {
            // Idle
            if (InputProvider.Instance.MoveInput == Vector2.zero)
            {
                _playerManager.ChangePlayerState(_playerManager.IdlePlayerState);
            }
        }
    }
}
