namespace Battleship.Domain
{
    public abstract class GameState
    {
    }

    public class GameFinished : GameState
    {
        public Player Winner { get; set; }
        public Player Loser { get; set; }
    }

    public class GameRunning : GameState
    {
    }
}