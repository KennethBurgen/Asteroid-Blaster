using UnityEngine;
using Utilities;
using Utilities.StateMachineSystem.Interfaces;

namespace Player.PlayerStates
{
    public class IdlePlayerState : IFixedUpdatableState
    {
        private readonly PlayerManager _playerManager;

        public IdlePlayerState(PlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public void OnEnter()
        {
            // to be done
        }

        public void OnExit()
        {
            // to be done
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
            if (InputProvider.Instance.MoveInput != UnityEngine.Vector2.zero)
            {
                _playerManager.ChangePlayerState(_playerManager.MovingPlayerState);
            }
        }
    }
}
