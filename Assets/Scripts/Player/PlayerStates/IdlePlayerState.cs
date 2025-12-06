using System.Runtime.CompilerServices;
using Player.Interfaces;
using UnityEngine;
using Utilities;
using Utilities.Interfaces;
using Utilities.StateMachineSystem.Interfaces;

[assembly: InternalsVisibleTo("Tests.EditMode.Player")]

namespace Player.PlayerStates
{
    public class IdlePlayerState : IFixedUpdatableState
    {
        private readonly IPlayerManager _playerManager;
        private readonly IPlayerController _playerController;
        internal IInputProvider _inputProvider = InputProvider.Instance;

        public IdlePlayerState(IPlayerManager playerManager, IPlayerController playerController)
        {
            _playerManager = playerManager;
            _playerController = playerController;
        }

        public void OnEnter()
        {
            // to be done
            _playerController.MovePlayer(Vector2.zero);
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

        /// <summary>
        /// Prüft die Bedingungen ob zu einem anderen möglichen PlayerState gewechselt werden kann
        /// </summary>
        public void CheckTransition()
        {
            // Moving
            if (_inputProvider.MoveInput != Vector2.zero)
            {
                _playerManager.ChangePlayerState(_playerManager.MovingPlayerState);

                // Damit sich der Spieler direkt bewegt und keine frames zwischen Eingabe und erstem Update in MovingState zu verlieren
                _playerController.MovePlayer(_inputProvider.MoveInput);
            }
        }
    }
}
