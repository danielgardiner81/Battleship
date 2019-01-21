namespace Battleship.Domain
{
    public class AttackResult
    {
        public static readonly AttackResult NoShipHit = new AttackResult {ShipSunk = false, ShipHit = false};
        public bool ShipHit { get; set; }
        public bool ShipSunk { get; set; }
    }
}