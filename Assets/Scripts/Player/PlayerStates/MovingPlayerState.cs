using UnityEngine;
using Utilities;
using Utilities.StateMachineSystem.Interfaces;

namespace Player.PlayerStates
{
    public class MovingPlayerState : IFixedUpdatableState
    {
        private readonly PlayerManager _playerManager;
        private readonly PlayerController _playerController;

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
        }

        public void OnFixedUpdate()
        {
            Vector2 movement = InputProvider.Instance.MoveInput;
            if (movement != Vector2.zero)
            {
                _playerController.MovePlayer();
            }

            CheckTransition();
        }

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
