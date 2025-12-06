using System.Runtime.CompilerServices;
using Player.Interfaces;
using UnityEngine;
using Utilities;
using Utilities.Interfaces;
using Utilities.StateMachineSystem.Interfaces;

[assembly: InternalsVisibleTo("Tests.EditMode.Player")]

namespace Player.PlayerStates
{
    public class MovingPlayerState : IFixedUpdatableState
    {
        private readonly IPlayerManager _playerManager;
        private readonly IPlayerController _playerController;
        internal IInputProvider _inputProvider = InputProvider.Instance;

        internal Vector2 _movement;

        public MovingPlayerState(IPlayerManager playerManager, IPlayerController playerController)
        {
            _playerManager = playerManager;
            _playerController = playerController;
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
            _movement = _inputProvider.MoveInput;

            _playerController.HorizontalSpeedControl();
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
            if (_inputProvider.MoveInput == Vector2.zero)
            {
                _playerManager.ChangePlayerState(_playerManager.IdlePlayerState);
            }
        }
    }
}
