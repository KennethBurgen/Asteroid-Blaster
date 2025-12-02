using UnityEngine;

namespace Utilities
{
    public class Bootstrap : MonoBehaviour
    {
        private GlobalContext _context;

        [SerializeField]
        private InputProvider inputProvider;

        void Awake()
        {
            _context = new GlobalContext();
            _context.BindInputProvider(inputProvider);

            // Persistent
            DontDestroyOnLoad(gameObject);
        }
    }
}
