using System;
using Core.GameManagerSystem.GameStates;
using Utilities.StateMachineSystem;

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
        public IGameState CurrentGameState => (IGameState)_stateMachine.CurrentState;

        // GameStates
        public MainMenuGameState MainMenuGameState { get; private set; }
        public GameOverGameState GameOverGameState { get; private set; }
        public PlayingGameState PlayingGameState { get; private set; }

        // Fields
        private int _seed;
        private int _minSeedLength;
        public int SEED => _seed;

        // Events
        public event Action<IGameState> OnGameStateChanged;

        private GameManager()
        {
            _stateMachine = new StateMachine();
            // GameStates
            MainMenuGameState = new MainMenuGameState();
            GameOverGameState = new GameOverGameState();
            PlayingGameState = new PlayingGameState();
        }

        /// <summary>
        /// Verlässt den alten GameState (falls vorhanden) und wechselt in den neuen GameState und löst das <see cref="Action">OnGameStateChanged</see> event aus
        /// </summary>
        /// <param name="newGameState">ein GameState vom Interface <see cref="IGameState"/></param>
        public void ChangeGameState(IGameState newGameState)
        {
            _stateMachine.ChangeState(newGameState);
            OnGameStateChanged?.Invoke(newGameState);
        }

        /// <summary>
        /// Setzt einen neuen Seed, sofern dessen Bedingungen erfüllt sind
        /// </summary>
        /// <param name="seed">ein <see cref="int"/></param>
        /// <returns></returns>
        public bool SetSeedSuccessful(int seed)
        {
            if (Math.Abs(seed).ToString().Length < _minSeedLength && seed == 0)
                return false;

            _seed = seed;
            return true;
        }
    }
}
