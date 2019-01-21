using System.Linq;

namespace Battleship.Domain
{
    public class Ship
    {
        private readonly bool[] hull;

        public Ship(int length)
        {
            hull = Enumerable.Repeat(true, length).ToArray();
        }

        public int Height => 1;
        public int Width => hull.Length;
        public bool IsDestroyed() => hull.All(o => !o);

        public AttackResult Attack(Position shipPosition)
        {
            if (shipPosition.Y != 0) return new AttackResult {ShipHit = false, ShipSunk = IsDestroyed()};
            if (shipPosition.X < 0) return new AttackResult {ShipHit = false, ShipSunk = IsDestroyed()};
            if (shipPosition.X >= hull.Length) return new AttackResult {ShipHit = false, ShipSunk = IsDestroyed()};

            hull[shipPosition.X] = false;
            return new AttackResult {ShipHit = true, ShipSunk = IsDestroyed()};
        }
    }
}