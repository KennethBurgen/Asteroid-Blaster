namespace Utilities.StateMachineSystem.Interfaces
{
    public interface IFixedUpdatableState : IUpdatableState
    {
        void OnFixedUpdate();
    }
}
