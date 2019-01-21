using Battleship.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [SetUp]
        public void SetUp()
        {
            builder = new GameBuilder();
            builder.PlaceShip(1, new Ship(2), new Position(5, 5), Orientation.Horizontal);
            builder.PlaceShip(1, new Ship(6), new Position(3, 2), Orientation.Vertical);
            builder.PlaceShip(2, new Ship(2), new Position(7, 5), Orientation.Vertical);
            game = builder.StartGame();
        }

        private GameBuilder builder;
        private Game game;

        [Test]
        public void Player1_victory()
        {
            game.Attack(new Position(7, 5)).Should().BeTrue();
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.Attack(new Position(7, 6)).Should().BeTrue();
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.State.Should().BeOfType<GameFinished>().Which.Winner.Name.Should().Be("Alice");
        }

        [Test]
        public void Player2_victory()
        {
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.Attack(new Position(5, 5)).Should().BeTrue();
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.Attack(new Position(6, 5)).Should().BeTrue();
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.Attack(new Position(3, 2)).Should().BeTrue();
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.Attack(new Position(3, 3)).Should().BeTrue();
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.Attack(new Position(3, 4)).Should().BeTrue();
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.Attack(new Position(3, 5)).Should().BeTrue();
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.Attack(new Position(3, 6)).Should().BeTrue();
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.Attack(new Position(3, 7)).Should().BeTrue();
            game.State.Should().BeOfType<GameFinished>().Which.Winner.Name.Should().Be("Bob");
        }
    }
}