using Battleship.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Battleship.Tests.Domain
{
    [TestFixture]
    public class ShipTests
    {
        private Ship ship;

        [Test]
        public void Initial_state()
        {
            ship = new Ship(10);
            ship.IsDestroyed().Should().BeFalse();
        }
    }
}