using UnityEngine;

namespace Utilities.Interfaces
{
    public interface IInputProvider
    {
        public Vector2 MoveInput { get; }
        public bool FireInput { get; }
        public bool BackInput { get; }
        public bool SubmitInput { get; }
    }
}
