using Moq;
using NUnit.Framework;
using Utilities.StateMachineSystem;
using Utilities.StateMachineSystem.Interfaces;

namespace Tests.EditMode.Utilities.StateMachineSystem
{
    public class StateMachineTest
    {
        private StateMachine _stateMachine;

        [SetUp]
        public void Setup()
        {
            _stateMachine = new StateMachine();
        }

        [TearDown]
        public void TearDown()
        {
            _stateMachine = null;
        }

        [Test]
        public void CanChangeState()
        {
            var mockState = new Mock<IState>();
            var mockState2 = new Mock<IState>();

            _stateMachine.ChangeState(mockState.Object);
            _stateMachine.ChangeState(mockState2.Object);

            mockState.Verify(mock => mock.OnEnter(), Times.Once);
            mockState.Verify(mock => mock.OnExit(), Times.Once);
            mockState2.Verify(mock => mock.OnEnter(), Times.Once);
        }

        [Test]
        public void CanDoAllTypesOfUpdatesOnUpdatableStates()
        {
            var mockState = new Mock<IUpdatableState>();
            var mockState2 = new Mock<IFixedUpdatableState>();

            _stateMachine.ChangeState(mockState.Object);

            _stateMachine.Update();

            _stateMachine.ChangeState(mockState2.Object);

            _stateMachine.Update();
            _stateMachine.FixedUpdate();

            // Verifies
            mockState.Verify(mock => mock.OnEnter(), Times.Once);
            mockState.Verify(mock => mock.OnExit(), Times.Once);
            mockState2.Verify(mock => mock.OnEnter(), Times.Once);

            mockState.Verify(mock => mock.OnUpdate(), Times.Once);
            mockState2.Verify(mock => mock.OnUpdate(), Times.Once);
            mockState2.Verify(mock => mock.OnFixedUpdate(), Times.Once);
        }
    }
}
