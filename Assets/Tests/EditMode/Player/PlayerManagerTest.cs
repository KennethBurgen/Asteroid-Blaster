using System.Collections;
using Moq;
using NUnit.Framework;
using Player;
using Player.Interfaces;
using Player.PlayerAttributes;
using Player.PlayerStates;
using UnityEngine;
using UnityEngine.TestTools;
using Utilities.StateMachineSystem.Interfaces;

namespace Tests.EditMode.Player
{
    public class PlayerManagerTest
    {
        private PlayerManager _sut;
        private GameObject _fakeGo;
        private Mock<IStateMachine> _stateMachineMock;

        [SetUp]
        public void Setup()
        {
            _stateMachineMock = new Mock<IStateMachine>();

            _fakeGo = new GameObject("FakeGameObject");
            _sut = _fakeGo.AddComponent<PlayerManager>();
            _sut._stateMachine = _stateMachineMock.Object;
        }

        [TearDown]
        public void TearDown()
        {
            _stateMachineMock = null;
            Object.DestroyImmediate(_sut);
            _sut = null;
            Object.DestroyImmediate(_fakeGo);
            _fakeGo = null;
        }

        [Test]
        public void ChangePlayerStateTestOk()
        {
            var playerControllerMock = new Mock<IPlayerController>();
            var movingPlayerState = new MovingPlayerState(_sut, playerControllerMock.Object);

            _sut.ChangePlayerState(movingPlayerState);

            _stateMachineMock.Verify(mock => mock.ChangeState(movingPlayerState), Times.Once);
        }

        [Test]
        public void UpdateCallsStateMachineUpdate()
        {
            _sut.Update();
            _stateMachineMock.Verify(mock => mock.Update(), Times.Once);
        }

        [Test]
        public void FixedUpdateCallsStateMachineFixedUpdate()
        {
            _sut.FixedUpdate();
            _stateMachineMock.Verify(mock => mock.FixedUpdate(), Times.Once);
        }

        [Test]
        public void AwakeSetsReferencesAndChangesToDefaultPlayerState()
        {
            _sut.playerAttributes = ScriptableObject.CreateInstance<PlayerAttributesSO>();

            Assert.That(_sut._playerController, Is.Null, "PlayerController not set");
            Assert.That(_sut._playerAttributesManager, Is.Null, "PlayerAttributesManager not set");
            Assert.That(_sut.IdlePlayerState, Is.Null, "IdlePlayerState not set");
            Assert.That(_sut.MovingPlayerState, Is.Null, "MovingPlayerState not set");

            _sut.Awake();

            Assert.That(_sut._playerController, Is.Not.Null, "PlayerController is set");
            Assert.That(
                _sut._playerAttributesManager,
                Is.Not.Null,
                "PlayerAttributesManager is set"
            );
            Assert.That(_sut.IdlePlayerState, Is.Not.Null, "IdlePlayerState is set");
            Assert.That(_sut.MovingPlayerState, Is.Not.Null, "MovingPlayerState is set");
            Assert.That(
                _sut._stateMachine.CurrentState,
                Is.EqualTo(_sut.IdlePlayerState),
                "StateMachines current State is IdlePlayerState"
            );
        }
    }
}
