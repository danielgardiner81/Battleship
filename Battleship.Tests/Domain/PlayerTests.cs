using System.Collections.Generic;
using Battleship.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Battleship.Tests.Domain
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Attack_hits_ship()
        {
            var player = new Player("Player 1", new List<PlayersShip>
            {
                new PlayersShip(new Ship(2), new Position(5, 5), Orientation.Horizontal)
            });
            player.Attack(new Position(5, 5)).ShipHit.Should().BeTrue();
        }

        [Test]
        public void Name()
        {
            new Player("Player 1").Name.Should().Be("Player 1");
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Name_must_not_be_null_or_empty(string name)
        {
            this.Invoking(o => new Player(name)).Should().Throw<InvalidStateException>();
        }
    }
}