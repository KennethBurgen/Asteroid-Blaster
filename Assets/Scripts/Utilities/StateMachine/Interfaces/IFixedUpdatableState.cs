namespace Utilities.StateMachine.Interfaces
{
    public interface IFixedUpdatableState : IUpdatableState
    {
        void OnFixedUpdate();
    }
}
