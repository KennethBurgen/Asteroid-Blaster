using Player.PlayerStates;
using UnityEngine;
using Utilities.StateMachineSystem;
using Utilities.StateMachineSystem.Interfaces;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        // Referenzen
        internal IStateMachine _stateMachine;

        // PlayerStates
        public IdlePlayerState IdlePlayerState { get; private set; }
        public MovingPlayerState MovingPlayerState { get; private set; }

        private void Awake()
        {
            _stateMachine = new StateMachine();
            IdlePlayerState = new IdlePlayerState();
            MovingPlayerState = new MovingPlayerState();
        }
    }
}
