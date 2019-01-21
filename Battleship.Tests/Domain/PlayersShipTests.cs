using Battleship.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Battleship.Tests.Domain
{
    [TestFixture]
    public class PlayersShipTests
    {
        private PlayersShip ship;                                                                                                    
        private readonly Position absolutePosition = new Position(5, 10);

        [Test]
        public void Attack_uses_relative_coordinates_to_the_hull()
        {
            ship = new PlayersShip(new Ship(5), absolutePosition, Orientation.Vertical);
            ship.Attack(new Position(5, 14)).ShipHit.Should().BeTrue();

            ship = new PlayersShip(new Ship(5), absolutePosition, Orientation.Horizontal);
            ship.Attack(new Position(9, 10)).ShipHit.Should().BeTrue();
        }

        [Test]
        public void Attack_should_return_true_when_ship_is_hit()
        {
            ship = new PlayersShip(new Ship(5), absolutePosition, Orientation.Vertical);
            ship.Attack(new Position(5, 14)).ShipHit.Should().BeTrue();
        }

        [Test]
        public void Attack_will_destroy_the_ship_if_all_hull_is_hit()
        {
            ship = new PlayersShip(new Ship(3), absolutePosition, Orientation.Vertical);
            ship.Attack(new Position(5, 10));
            ship.Attack(new Position(5, 11));
            ship.Attack(new Position(5, 12));
            ship.IsDestroyed.Should().BeTrue();
        }

        [Test]
        public void Ship_should_be_undestroyed_when_created()
        {
            ship = new PlayersShip(new Ship(5), absolutePosition, Orientation.Horizontal);
            ship.IsDestroyed.Should().BeFalse();
        }
    }
}