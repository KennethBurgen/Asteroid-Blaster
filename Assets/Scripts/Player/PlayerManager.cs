using System;
using Player.PlayerStates;
using UnityEngine;
using Utilities.StateMachineSystem;
using Utilities.StateMachineSystem.Interfaces;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        // Referenzen
        private IStateMachine _stateMachine;

        // PlayerStates
        public IdlePlayerState IdlePlayerState { get; private set; }
        public MovingPlayerState MovingPlayerState { get; private set; }

        private void Awake()
        {
            _stateMachine = new StateMachine();
            IdlePlayerState = new IdlePlayerState(this);
            MovingPlayerState = new MovingPlayerState();

            _stateMachine.ChangeState(IdlePlayerState);
        }

        public void Update()
        {
            _stateMachine.Update();
        }

        public void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        /// <summary>
        /// Ruft <see cref="StateMachine.ChangeState"/>
        /// </summary>
        /// <param name="newPlayerState">ein PlayerState vom Interface <see cref="IUpdatableState"/></param>
        public void ChangePlayerState(IUpdatableState newPlayerState)
        {
            _stateMachine.ChangeState(newPlayerState);
        }
    }
}
