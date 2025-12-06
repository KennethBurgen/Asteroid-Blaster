using Moq;
using NUnit.Framework;
using Player.Interfaces;
using Player.PlayerStates;
using UnityEngine;
using Utilities.Interfaces;

namespace Tests.EditMode.Player.PlayerStates
{
    public class MovingPlayerStateTest
    {
        private Mock<IPlayerManager> _playerManager;
        private Mock<IPlayerController> _playerController;
        private Mock<IInputProvider> _inputProvider;

        private MovingPlayerState _sut;

        [SetUp]
        public void Setup()
        {
            _playerManager = new Mock<IPlayerManager>();
            _playerController = new Mock<IPlayerController>();
            _inputProvider = new Mock<IInputProvider>();

            _sut = new MovingPlayerState(_playerManager.Object, _playerController.Object)
            {
                _inputProvider = _inputProvider.Object,
            };
        }

        [TearDown]
        public void TearDown()
        {
            _sut = null;
            _playerManager = null;
            _playerController = null;
        }

        [Test]
        public void OnUpdateOk()
        {
            var movementVector = new Vector2(-1, 0);
            _inputProvider.Setup(mock => mock.MoveInput).Returns(movementVector);

            _sut.OnUpdate();

            _inputProvider.Verify(mock => mock.MoveInput, Times.Once);
            _playerController.Verify(mock => mock.HorizontalSpeedControl(), Times.Once);
            Assert.AreEqual(movementVector, _sut._movement, "Movement Vector was set");
        }

        [Test]
        public void OnFixedUpdateOk()
        {
            var movementVector = new Vector2(0, 0);
            _sut._movement = movementVector;

            _sut.OnFixedUpdate();

            _playerController.Verify(mock => mock.MovePlayer(movementVector));

            // Erste Abfrage in CheckTransition
            _inputProvider.Verify(mock => mock.MoveInput, Times.Once);
        }

        [Test]
        public void CheckTransitonTransitionsToIdlePlayerState()
        {
            var movementVector = new Vector2(0, 0);
            _inputProvider.Setup(mock => mock.MoveInput).Returns(movementVector);

            var idlePlayerState = new IdlePlayerState(
                _playerManager.Object,
                _playerController.Object
            );
            _playerManager.Setup(mock => mock.IdlePlayerState).Returns(idlePlayerState);

            _sut.CheckTransition();

            _playerManager.Verify(mock => mock.ChangePlayerState(idlePlayerState));
        }
    }
}
