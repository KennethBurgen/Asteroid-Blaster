using UnityEngine;
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
            Debug.Log("Entering Moving");
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
            // to be done
        }

        public void CheckTransition()
        {
            // to be done
        }
    }
}
