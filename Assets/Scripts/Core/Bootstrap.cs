using Core.GameManagerSystem;
using UnityEngine;
using Utilities;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        private GlobalContext _context;
        private GameManager _gameManager;

        [SerializeField]
        private InputProvider inputProvider;

        void Awake()
        {
            // Referenzen an globale Kontext binden
            _context = GlobalContext.Instance;
            _context.BindInputProvider(inputProvider);

            _gameManager = GameManager.Instance;
            _context.BindGameManager(_gameManager);
            _gameManager.ChangeGameState(_gameManager.MainMenuGameState);

            // Persistent
            DontDestroyOnLoad(gameObject);

            // Nächste Szene laden
        }
    }
}
