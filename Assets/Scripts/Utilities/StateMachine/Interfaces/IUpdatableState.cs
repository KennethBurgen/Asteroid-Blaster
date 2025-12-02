namespace Utilities.StateMachine.Interfaces
{
    public interface IUpdatableState : IState
    {
        void OnUpdate();
    }
}
