using UnityEngine;

namespace Utilities
{
    public class InputProvider : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;

        public Vector2 MoveInput =>
            _playerInputActions?.Player.Move.ReadValue<Vector2>() ?? Vector2.zero;
        public bool FireInput => _playerInputActions?.Player.Fire.IsPressed() ?? false;
        public bool BackInput => _playerInputActions?.Player.Back.WasPressedThisFrame() ?? false;
        public bool SubmitInput =>
            _playerInputActions?.Player.Submit.WasPressedThisFrame() ?? false;

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
