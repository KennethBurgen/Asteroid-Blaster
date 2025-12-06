using UnityEngine;

namespace Player.Interfaces
{
    public interface IPlayerController
    {
        public void MovePlayer(Vector2 movement);
        public void HorizontalSpeedControl();
    }
}
