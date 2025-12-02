using UnityEngine;

namespace Utilities
{
    public class InputProvider : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;

        public Vector2 MoveInput => _playerInputActions.Player.Move.ReadValue<Vector2>();
        public bool FireInput => _playerInputActions.Player.Fire.IsPressed();
        public bool BackInput => _playerInputActions.Player.Back.WasPressedThisFrame();
        public bool SubmitInput => _playerInputActions.Player.Submit.WasPressedThisFrame();

        private void OnEnable()
        {
            _playerInputActions ??= new PlayerInputActions();
            _playerInputActions.Enable();
        }

        private void OnDisable()
        {
            _playerInputActions.Disable();
        }
    }
}
