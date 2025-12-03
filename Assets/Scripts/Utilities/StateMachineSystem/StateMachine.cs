using Utilities.StateMachineSystem.Interfaces;

namespace Utilities.StateMachineSystem
{
    public class StateMachine
    {
        private IState _currentState;

        public void ChangeState(IState newState)
        {
            _currentState?.OnExit();
            _currentState = newState;
            _currentState?.OnEnter();
        }

        public void Update()
        {
            if (_currentState is IUpdatableState updatableState)
            {
                updatableState.OnUpdate();
            }
        }

        public void FixedUpdate()
        {
            if (_currentState is IFixedUpdatableState fixedUpdatableState)
            {
                fixedUpdatableState.OnFixedUpdate();
            }
        }
    }
}
