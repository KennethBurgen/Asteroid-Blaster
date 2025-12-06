using Moq;
using NUnit.Framework;
using Player.Interfaces;
using Player.PlayerStates;
using UnityEngine;
using Utilities.Interfaces;

namespace Tests.EditMode.Player.PlayerStates
{
    public class IdlePlayerStateTest
    {
        private Mock<IPlayerManager> _playerManager;
        private Mock<IPlayerController> _playerController;
        private Mock<IInputProvider> _inputProvider;

        private IdlePlayerState _sut;

        [SetUp]
        public void Setup()
        {
            _playerManager = new Mock<IPlayerManager>();
            _playerController = new Mock<IPlayerController>();
            _inputProvider = new Mock<IInputProvider>();

            _sut = new IdlePlayerState(_playerManager.Object, _playerController.Object)
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
        public void OnEnterOk()
        {
            _sut.OnEnter();

            _playerController.Verify(mock => mock.MovePlayer(Vector2.zero));
        }

        [Test]
        public void CheckTransitionTransitionsToMovingPlayerState()
        {
            var movingPlayerState = new MovingPlayerState(
                _playerManager.Object,
                _playerController.Object
            );

            var vector2 = new Vector2(1, 0);

            _inputProvider.Setup(mock => mock.MoveInput).Returns(vector2);
            _playerManager.Setup(mock => mock.MovingPlayerState).Returns(movingPlayerState);

            _sut.CheckTransition();

            _playerManager.Verify(mock => mock.ChangePlayerState(movingPlayerState), Times.Once);
            _playerController.Verify(mock => mock.MovePlayer(vector2), Times.Once);
        }

        [Test]
        public void CheckTransitionNotTransitionsToMovingPlayerState()
        {
            var movingPlayerState = new MovingPlayerState(
                _playerManager.Object,
                _playerController.Object
            );

            var vector2 = new Vector2(0, 0);

            _inputProvider.Setup(mock => mock.MoveInput).Returns(vector2);
            _playerManager.Setup(mock => mock.MovingPlayerState).Returns(movingPlayerState);

            _sut.CheckTransition();

            _playerManager.Verify(mock => mock.ChangePlayerState(movingPlayerState), Times.Never);
            _playerController.Verify(mock => mock.MovePlayer(vector2), Times.Never);
        }
    }
}
