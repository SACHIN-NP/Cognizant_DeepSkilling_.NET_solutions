using Moq;
using NUnit.Framework;
using PlayersManagerLib;
using System;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> _playerMapperMock;

        [OneTimeSetUp]
        public void Setup()
        {
            _playerMapperMock = new Mock<IPlayerMapper>();
        }

        [Test]
        public void RegisterNewPlayer_WithNewName_ReturnsPlayer()
        {
            // Arrange: Mock database to return false (name doesn't exist)
            _playerMapperMock
                .Setup(m => m.IsPlayerNameExistsInDb(It.IsAny<string>()))
                .Returns(false);

            // Act
            var player = Player.RegisterNewPlayer("NewPlayer", _playerMapperMock.Object);

            // Assert
            Assert.That(player, Is.Not.Null);
            Assert.That(player.Name, Is.EqualTo("NewPlayer"));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));
        }

        [Test]
        public void RegisterNewPlayer_WithExistingName_ThrowsException()
        {
            // Arrange: Mock database to return true (name exists)
            _playerMapperMock
                .Setup(m => m.IsPlayerNameExistsInDb(It.IsAny<string>()))
                .Returns(true);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => 
                Player.RegisterNewPlayer("ExistingPlayer", _playerMapperMock.Object));
            
            Assert.That(ex.Message, Is.EqualTo("Player name already exists"));
        }
    }
}
