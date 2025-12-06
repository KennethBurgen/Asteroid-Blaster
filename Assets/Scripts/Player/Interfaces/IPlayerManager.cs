using Utilities.StateMachineSystem.Interfaces;

namespace Player.Interfaces
{
    public interface IPlayerManager
    {
        public IFixedUpdatableState IdlePlayerState { get; }
        public IFixedUpdatableState MovingPlayerState { get; }
        public void ChangePlayerState(IUpdatableState newPlayerState);
    }
}
