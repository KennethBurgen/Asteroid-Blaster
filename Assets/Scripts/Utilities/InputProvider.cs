using UnityEngine;

namespace Utilities
{
    public class InputProvider : MonoBehaviour
    {
        public static InputProvider Instance { get; private set; }
        private PlayerInputActions _playerInputActions;

        public Vector2 MoveInput =>
            _playerInputActions?.Player.Move.ReadValue<Vector2>() ?? Vector2.zero;
        public bool FireInput => _playerInputActions?.Player.Fire.IsPressed() ?? false;
        public bool BackInput => _playerInputActions?.Player.Back.WasPressedThisFrame() ?? false;
        public bool SubmitInput =>
            _playerInputActions?.Player.Submit.WasPressedThisFrame() ?? false;

        #region Singleton

        /// <summary>
        /// Stellt sicher, dass der InputProvider nur einmal existiert - Singleton
        /// </summary>
        private void InitializeSingleton()
        {
            if (Instance is not null && Instance != this)
            {
                Debug.LogWarning(
                    "Deleting Component - InputProvider - on Gameobject - "
                        + gameObject.name
                        + " - because InputProvider already exists."
                );
                Destroy(this);
                return;
            }

            Instance = this;
        }

        #endregion

        private void OnEnable()
        {
            InitializeSingleton();

            _playerInputActions ??= new PlayerInputActions();
            _playerInputActions.Enable();
        }

        private void OnDisable()
        {
            _playerInputActions.Disable();
        }
    }
}
