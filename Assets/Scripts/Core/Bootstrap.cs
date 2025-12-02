using UnityEngine;
using Utilities;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        private GlobalContext _context;

        [SerializeField]
        private InputProvider inputProvider;

        void Awake()
        {
            // Referenzen an globale Kontext binden
            _context = GlobalContext.Instance;
            _context.BindInputProvider(inputProvider);

            // Persistent
            DontDestroyOnLoad(gameObject);

            // Nächste Szene laden
        }
    }
}
