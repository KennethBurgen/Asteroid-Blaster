using System.Collections;
using NUnit.Framework;
using Player.PlayerAttributes;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.EditMode.Player.PlayerAttributes
{
    public class PlayerAttributesManagerTest
    {
        private PlayerAttributesManager _sut;
        private PlayerAttributesSO _playerAttributes;

        [TearDown]
        public void TearDown()
        {
            _playerAttributes = null;
            _sut = null;
        }

        [Test]
        public void SetAttributesTest()
        {
            _playerAttributes = ScriptableObject.CreateInstance<PlayerAttributesSO>();
            _playerAttributes.HorizontalMovementSpeed = 10f;
            _playerAttributes.MaxHealth = 4;

            _sut = new PlayerAttributesManager(_playerAttributes);

            Assert.That(_playerAttributes.HorizontalMovementSpeed, Is.EqualTo(10f));
            Assert.That(_playerAttributes.MaxHealth, Is.EqualTo(4));
        }
    }
}
