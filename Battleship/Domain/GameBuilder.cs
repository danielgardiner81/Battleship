using System;
using System.Collections.Generic;

namespace Battleship.Domain
{
    public class GameBuilder
    {
        public GameBuilder()
        {
            Player1 = new Player("Alice");
            Player2 = new Player("Bob");
            PlacedShips = new Dictionary<Player, List<PlayersShip>>
            {
                {Player1, new List<PlayersShip>()},
                {Player2, new List<PlayersShip>()}
            };
        }

        public Board Board { get; }
        public Dictionary<Player, List<PlayersShip>> PlacedShips { get; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public GameBuilder PlaceShip(int playerNumber, Ship ship, Position position, Orientation orientation)
        {
            var player = playerNumber == 1 ? Player1 : Player2;
            AssertValidatePlacement();
            PlacedShips[player].Add(new PlayersShip(ship, position, orientation));
            return this;

            void AssertValidatePlacement()
            {
                if (playerNumber > 2 || playerNumber < 1)
                    throw new InvalidStateException("Only two can play");

                if (ship == null)
                    throw new InvalidStateException("Must provide a ship instance");

                if (!Enum.IsDefined(typeof(Orientation), orientation))
                    throw new InvalidStateException("Position cannot contain a negative component");

                var shipBounds = CalculateShipBounds();

                if (!player.Board.IsWithinBounds(position, shipBounds))
                    throw new InvalidStateException("Ship is not within the bounds of the board");

                (int Right, int Bottom) CalculateShipBounds()
                {
                    switch (orientation)
                    {
                        case Orientation.Horizontal:
                            return (position.X + ship.Width, position.Y + ship.Height);
                        case Orientation.Vertical:
                            return (position.X + ship.Height, position.Y + ship.Width);
                        default:
                            throw new InvalidStateException("Invalid orientation");
                    }
                }
            }
        }

        public Game StartGame()
        {
            Player1 = new Player(Player1.Name, PlacedShips[Player1]);
            Player2 = new Player(Player2.Name, PlacedShips[Player2]);
            return new Game(this);
        }
    }
}