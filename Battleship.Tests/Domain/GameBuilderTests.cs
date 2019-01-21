using Battleship.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Battleship.Tests.Domain
{
    [TestFixture]
    public class GameBuilderTests
    {
        [SetUp]
        public void SetUp()
        {
            builder = new GameBuilder();
        }

        private GameBuilder builder;


        [Test]
        public void PlaceShip()
        {
            builder.PlaceShip(1, new Ship(1), new Position(0, 0), Orientation.Horizontal);
            builder.PlaceShip(1, new Ship(1), new Position(0, 0), Orientation.Vertical);
            builder.PlaceShip(1, new Ship(9), new Position(0, 0), Orientation.Vertical);
        }

        [Test]
        public void PlaceShip_orientation_must_be_horizontal_or_vertical()
        {
            this.Invoking(o => builder.PlaceShip(1, new Ship(1), new Position(0, 0), (Orientation) (-1))).Should().Throw<InvalidStateException>();
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(-1, -1)]
        [TestCase(0, -1)]
        public void PlaceShip_position_must_be_non_negative(int x, int y)
        {
            this.Invoking(o => builder.PlaceShip(1, new Ship(1), new Position(x, y), Orientation.Horizontal)).Should().Throw<InvalidStateException>();
        }

        [Test]
        public void PlaceShip_ship_cant_be_null()
        {
            this.Invoking(o => builder.PlaceShip(1, null, new Position(0, 0), Orientation.Horizontal)).Should().Throw<InvalidStateException>();
        }

        [Test]
        [TestCase(Orientation.Horizontal, 5, 9, 0)]
        [TestCase(Orientation.Horizontal, 5, 8, 0)]
        [TestCase(Orientation.Horizontal, 5, 7, 0)]
        [TestCase(Orientation.Horizontal, 5, 6, 0)]
        [TestCase(Orientation.Vertical, 5, 0, 9)]
        [TestCase(Orientation.Vertical, 5, 0, 8)]
        [TestCase(Orientation.Vertical, 5, 0, 7)]
        [TestCase(Orientation.Vertical, 5, 0, 6)]
        public void PlaceShip_throws_if_out_of_bounds(Orientation orientation, int shipLength, int x, int y)
        {
            this.Invoking(o => builder.PlaceShip(1, new Ship(shipLength), new Position(x, y), orientation)).Should().Throw<InvalidStateException>();
        }

        [Test]
        public void PlaceShip_throws_if_unknown_player_used()
        {
            this.Invoking(o => builder.PlaceShip(0, new Ship(1), new Position(0, 0), Orientation.Horizontal)).Should().Throw<InvalidStateException>();
            this.Invoking(o => builder.PlaceShip(3, new Ship(1), new Position(0, 0), Orientation.Horizontal)).Should().Throw<InvalidStateException>();
        }

        [Test]
        public void Players()
        {
            builder.Player1.Should().BeOfType<Player>();
            builder.Player2.Should().BeOfType<Player>();
            builder.Player1.Name.Should().Be("Alice");
            builder.Player2.Name.Should().Be("Bob");
        }
    }
}