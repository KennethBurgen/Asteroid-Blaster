using UnityEngine;
using UnityEngine.InputSystem;

namespace Utilities
{
    public class InputProvider : MonoBehaviour
    {
        private readonly PlayerInputActions _playerInputActions = new PlayerInputActions();

        private void OnEnable()
        {
            _playerInputActions.Enable();
        }

        private void OnDisable()
        {
            _playerInputActions.Disable();
        }
    }
}
