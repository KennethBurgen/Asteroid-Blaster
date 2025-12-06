using Player.Interfaces;
using Player.PlayerAttributes;
using Player.PlayerStates;
using UnityEngine;
using Utilities.StateMachineSystem;
using Utilities.StateMachineSystem.Interfaces;

namespace Player
{
    public class PlayerManager : MonoBehaviour, IPlayerManager
    {
        // Serializable Referenzen
        [SerializeField]
        private PlayerAttributesSO playerAttributes;

        // Referenzen
        private IStateMachine _stateMachine;
        private PlayerController _playerController;
        private PlayerAttributesManager _playerAttributesManager;

        // Player-States
        public IFixedUpdatableState IdlePlayerState { get; private set; }
        public IFixedUpdatableState MovingPlayerState { get; private set; }

        private void Awake()
        {
            // Referenzen ziehen bzw. instanzieren
            _stateMachine = new StateMachine();
            _playerController = GetComponent<PlayerController>();
            _playerAttributesManager = new PlayerAttributesManager(playerAttributes);

            // Player-States instanzieren
            IdlePlayerState = new IdlePlayerState(this, _playerController);
            MovingPlayerState = new MovingPlayerState(this, _playerController);

            // In default-State wechseln
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
