namespace Utilities
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

        /// <summary>
        /// Bindet einen InputProvider an den globalen Kontext
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
    }
}
