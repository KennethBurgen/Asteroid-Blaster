using UnityEngine;
using Utilities;
using Utilities.StateMachineSystem.Interfaces;

namespace Player.PlayerStates
{
    public class IdlePlayerState : IFixedUpdatableState
    {
        private readonly PlayerManager _playerManager;
        private readonly PlayerController _playerController;

        public IdlePlayerState(PlayerManager playerManager, PlayerController playerController)
        {
            _playerManager = playerManager;
            _playerController = playerController;
        }

        public void OnEnter()
        {
            // to be done
            Debug.Log("Entered IdlePlayerState");
            _playerController.MovePlayer();
        }

        public void OnExit()
        {
            // to be done
            Debug.Log("Exited IdlePlayerState");
        }

        public void OnUpdate()
        {
            // to be done
        }

        public void OnFixedUpdate()
        {
            CheckTransition();
        }

        public void CheckTransition()
        {
            // Moving
            if (InputProvider.Instance.MoveInput != Vector2.zero)
            {
                _playerManager.ChangePlayerState(_playerManager.MovingPlayerState);
            }
        }
    }
}
