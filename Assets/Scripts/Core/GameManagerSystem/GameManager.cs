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
        private StateMachine _stateMachine;

        // Fields
        private int _seed;
        public int SEED
        {
            get => _seed;
            set => _seed = value;
        }

        private GameManager()
        {
            _stateMachine = new StateMachine();
        }
    }
}
