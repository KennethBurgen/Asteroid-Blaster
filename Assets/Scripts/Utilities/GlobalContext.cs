namespace Utilities
{
    public class GlobalContext
    {
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
        
        // Globale Referenzen
        public readonly InputProvider InputProvider;

        private GlobalContext()
        {
            InputProvider = new InputProvider();
        }
    }
}