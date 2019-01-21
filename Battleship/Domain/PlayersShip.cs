using System;

namespace Battleship.Domain
{
    public class PlayersShip
    {
        private readonly Ship ship;

        public PlayersShip(Ship ship, Position position, Orientation orientation)
        {
            this.ship = ship;
            Position = position;
            Orientation = orientation;
        }

        public bool IsDestroyed => ship.IsDestroyed();
        public Orientation Orientation { get; }
        public Position Position { get; }

        public AttackResult Attack(Position attackPosition)
        {
            return ship.Attack(TranslateAttackPositionToHullCoordinates());

            Position TranslateAttackPositionToHullCoordinates()
            {
                var relativePosition = new Position(attackPosition.X - Position.X, attackPosition.Y - Position.Y);
                switch (Orientation)
                {
                    case Orientation.Horizontal:
                        return new Position(relativePosition.X, relativePosition.Y);
                    case Orientation.Vertical:
                        return new Position(relativePosition.Y, relativePosition.X);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}