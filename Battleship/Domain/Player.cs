using System.Collections.Generic;
using System.Linq;

namespace Battleship.Domain
{
    public class Player
    {
        public Player(string name, List<PlayersShip> ships = null)
        {
            if (name == null || string.IsNullOrWhiteSpace(name))
                throw new InvalidStateException("The player name is required");

            Board = new Board();
            Name = name;
            Ships = ships ?? new List<PlayersShip>();
        }

        public string Name { get; }

        public Board Board { get; }

        private List<PlayersShip> Ships { get; }
        public int DestroyedShips => Ships.Count(o => o.IsDestroyed);
        public int TotalShips => Ships.Count;

        public AttackResult Attack(Position position)
        {
            return Ships.Select(o => o.Attack(position)).FirstOrDefault(o => o.ShipHit) ?? AttackResult.NoShipHit;
        }
    }
}