using System;
using Core.GameManagerSystem;
using Moq;
using NUnit.Framework;
using Utilities.StateMachineSystem.Interfaces;

namespace Tests.EditMode.Core.GameManagerSystem
{
    public class GameManagerTest
    {
        private GameManager _gameManager;
        private Mock<IStateMachine> _stateMachineMock;

        private Action<IGameState> _handler;

        [SetUp]
        public void Setup()
        {
            _gameManager = GameManager.Instance;

            _stateMachineMock = new Mock<IStateMachine>();
            _gameManager._stateMachine = _stateMachineMock.Object;
        }

        [TearDown]
        public void TearDown()
        {
            _gameManager = null;
            _stateMachineMock = null;
        }

        [Test]
        public void CanChangeGameState()
        {
            var actionCounter = 0;
            _handler = _ => actionCounter++;

            _gameManager.OnGameStateChanged += _handler;

            var mockGameState = new Mock<IGameState>();
            var mockGameState2 = new Mock<IGameState>();
            _gameManager.ChangeGameState(mockGameState.Object);
            _stateMachineMock.Setup(mock => mock.CurrentState).Returns(mockGameState.Object);
            _gameManager.ChangeGameState(mockGameState2.Object);

            // Verifies
            _stateMachineMock.Verify(mock => mock.ChangeState(mockGameState.Object), Times.Once);
            _stateMachineMock.Verify(mock => mock.ChangeState(mockGameState2.Object), Times.Once);
            Assert.AreEqual(
                2,
                actionCounter,
                "OnGameStateChanged event should have been called twice"
            );

            _gameManager.OnGameStateChanged -= _handler;
        }

        [Test]
        public void CannotChangeGameStateIfSameGameState()
        {
            var actionCounter = 0;
            _handler = _ => actionCounter++;

            _gameManager.OnGameStateChanged += _handler;

            var mockGameState = new Mock<IGameState>();

            _gameManager.ChangeGameState(mockGameState.Object);
            _stateMachineMock.Setup(mock => mock.CurrentState).Returns(mockGameState.Object);
            _gameManager.ChangeGameState(mockGameState.Object);

            // Verifies
            _stateMachineMock.Verify(mock => mock.ChangeState(mockGameState.Object), Times.Once);
            Assert.AreEqual(1, actionCounter, "OnGameStateChanged event should have been called");

            _gameManager.OnGameStateChanged -= _handler;
        }
    }
}
