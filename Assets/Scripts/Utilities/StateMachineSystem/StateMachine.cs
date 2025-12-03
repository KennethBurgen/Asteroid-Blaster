using Utilities.StateMachineSystem.Interfaces;

namespace Utilities.StateMachineSystem
{
    public class StateMachine
    {
        public IState CurrentState { get; private set; }

        /// <summary>
        /// Verlässt den alten State (falls vorhanden) und wechselt in den neuen State
        /// </summary>
        /// <param name="newState">ein State vom Interface <see cref="IState"/></param>
        public void ChangeState(IState newState)
        {
            if (CurrentState == newState)
            {
                return;
            }

            CurrentState?.OnExit();
            CurrentState = newState;
            CurrentState?.OnEnter();
        }

        /// <summary>
        /// Sofern der momentane State vom Interface <see cref="IUpdatableState"/> ist wird dessen <see cref="IUpdatableState.OnUpdate"/> Methode aufgerufen
        /// </summary>
        public void Update()
        {
            if (CurrentState is IUpdatableState updatableState)
            {
                updatableState.OnUpdate();
            }
        }

        /// <summary>
        /// Sofern der momentane State vom Interface <see cref="IFixedUpdatableState"/> ist wird dessen <see cref="IFixedUpdatableState.OnFixedUpdate"/> Methode aufgerufen
        /// </summary>
        public void FixedUpdate()
        {
            if (CurrentState is IFixedUpdatableState fixedUpdatableState)
            {
                fixedUpdatableState.OnFixedUpdate();
            }
        }
    }
}
