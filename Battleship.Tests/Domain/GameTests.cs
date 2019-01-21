using Battleship.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Battleship.Tests.Domain
{
    [TestFixture]
    public class GameTests
    {
        [SetUp]
        public void SetUp()
        {
            builder = new GameBuilder();
            builder.PlaceShip(1, new Ship(2), new Position(3, 3), Orientation.Horizontal);
            builder.PlaceShip(2, new Ship(2), new Position(5, 5), Orientation.Horizontal);
            game = builder.StartGame();
        }

        private GameBuilder builder;
        private Game game;

        [Test]
        public void GameState_should_be_running_by_default()
        {
            game.State.Should().BeOfType<GameRunning>();
        }

        [Test]
        public void GameState_should_be_finsished_when_one_player_wins()
        {
            game.Attack(new Position(5, 5)).Should().BeTrue();
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.Attack(new Position(6, 5)).Should().BeTrue();
            game.Attack(new Position(0, 0)).Should().BeFalse();
            game.State.Should().BeOfType<GameFinished>();
        }

        [Test]
        public void Attack_ends_turn()
        {
            game.Attack(new Position(0, 0));
            game.CurrentPlayer.Name.Should().Be("Bob");
            game.Attack(new Position(0, 0));
            game.CurrentPlayer.Name.Should().Be("Alice");
        }

        [Test]
        public void Attack_throws_if_not_running()
        {
            game.Attack(new Position(0, 0));
            game.CurrentPlayer.Name.Should().Be("Bob");
            game.Attack(new Position(0, 0));
            game.CurrentPlayer.Name.Should().Be("Alice");
        }
    }
}