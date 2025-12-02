namespace Utilities.StateMachine.Interfaces
{
    public interface IState
    {
        void OnEnter();
        void OnExit();
    }
}
