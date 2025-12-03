using System;
using Core.GameManagerSystem.GameStates;
using Utilities.StateMachineSystem;
using Utilities.StateMachineSystem.Interfaces;

namespace Core.GameManagerSystem
{
    public class GameManager
    {
        #region Singleton

        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }

                return _instance;
            }
        }

        #endregion

        // Referenzen
        private readonly StateMachine _stateMachine;
        public IState CurrentGameState => _stateMachine.CurrentState;

        // GameStates
        public MainMenuGameState MainMenuGameState { get; private set; }
        public GameOverGameState GameOverGameState { get; private set; }
        public PlayingGameState PlayingGameState { get; private set; }

        // Fields
        private int _seed;
        private int _minSeedLength;
        public int SEED => _seed;

        // Events
        public event Action<IState> OnGameStateChanged;

        private GameManager()
        {
            _stateMachine = new StateMachine();
            // GameStates
            MainMenuGameState = new MainMenuGameState();
            GameOverGameState = new GameOverGameState();
            PlayingGameState = new PlayingGameState();
        }

        public void ChangeGameState(IState newGameState)
        {
            _stateMachine.ChangeState(newGameState);
            OnGameStateChanged?.Invoke(newGameState);
        }

        public bool SetSeedSuccessful(int seed)
        {
            if (Math.Abs(seed).ToString().Length < _minSeedLength && seed == 0)
                return false;

            _seed = seed;
            return true;
        }
    }
}
