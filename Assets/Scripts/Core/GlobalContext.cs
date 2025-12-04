using Core.GameManagerSystem;
using Utilities;

namespace Core
{
    public class GlobalContext
    {
        #region Singleton

        private static GlobalContext _instance;

        public static GlobalContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GlobalContext();
                }

                return _instance;
            }
        }

        #endregion

        // Globale Referenzen
        public InputProvider InputProvider { get; private set; }
        public GameManager GameManager { get; private set; }

        /// <summary>
        /// Bindet einen InputProvider an den <see cref="GlobalContext"/>
        /// </summary>
        /// <param name="inputProvider">ein <see cref="InputProvider"/></param>
        public void BindInputProvider(InputProvider inputProvider)
        {
            if (!inputProvider)
            {
                UnityEngine.Debug.LogError("InputProvider cannot be null");
                return;
            }
            InputProvider = inputProvider;
        }

        /// <summary>
        /// Bindet einen GameManager an den <see cref="GlobalContext"/>
        /// </summary>
        /// <param name="gameManager">ein <see cref="GameManager"/></param>
        public void BindGameManager(GameManager gameManager)
        {
            if (gameManager == null)
            {
                UnityEngine.Debug.LogError("GameManager cannot be null");
                return;
            }
            GameManager = gameManager;
        }
    }
}
