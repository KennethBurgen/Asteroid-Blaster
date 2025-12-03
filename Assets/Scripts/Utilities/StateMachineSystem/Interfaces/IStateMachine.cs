namespace Utilities.StateMachineSystem.Interfaces
{
    public interface IStateMachine
    {
        public IState CurrentState { get; }
        public void ChangeState(IState newState);
        public void Update();
        public void FixedUpdate();
    }
}
