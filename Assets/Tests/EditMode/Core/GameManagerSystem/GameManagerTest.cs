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
            _gameManager.ChangeGameState(mockGameState.Object);

            // Verifies
            _stateMachineMock.Verify(mock => mock.ChangeState(mockGameState.Object), Times.Once);
            Assert.AreEqual(1, actionCounter, "OnGameStateChanged event should have been called");

            _gameManager.OnGameStateChanged -= _handler;
        }
    }
}
