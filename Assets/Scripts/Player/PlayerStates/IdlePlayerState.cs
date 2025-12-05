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
            _playerController.MovePlayer(Vector2.zero);
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

        /// <summary>
        /// Prüft die Bedingungen ob zu einem anderen möglichen PlayerState gewechselt werden kann
        /// </summary>
        public void CheckTransition()
        {
            // Moving
            if (InputProvider.Instance.MoveInput != Vector2.zero)
            {
                _playerManager.ChangePlayerState(_playerManager.MovingPlayerState);

                // Damit sich der Spieler direkt bewegt und keine frames zwischen Eingabe und erstem Update in MovingState zu verlieren
                _playerController.MovePlayer(InputProvider.Instance.MoveInput);
            }
        }
    }
}
