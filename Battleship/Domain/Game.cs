using System;

namespace Battleship.Domain
{
    public class Game
    {
        public Game(GameBuilder builder)
        {
            Player1 = builder.Player1;
            Player2 = builder.Player2;
            CurrentPlayer = Player1;
        }

        public Player CurrentPlayer { get; private set; }
        private Player Player1 { get; }
        private Player Player2 { get; }
        public GameState State { get; private set; } = new GameRunning();

        public bool Attack(Position position)
        {
            var opponent = CurrentPlayer == Player1 ? Player2 : Player1;
            var attackResult = opponent.Attack(position);

            if (attackResult.ShipSunk)
            {
                Console.WriteLine($"{CurrentPlayer.Name} sunk {opponent.Name}'s ship after hitting at {position}!");
                CheckForVictory();
            }
            else if(attackResult.ShipHit)
            {
                Console.WriteLine($"{CurrentPlayer.Name} hit {opponent.Name}'s at {position}!");
            }
            else
            {
                Console.WriteLine($"{CurrentPlayer.Name} missed at {position}!");
            }

            EndTurn();

            return attackResult.ShipHit;

            void CheckForVictory()
            {
                if (opponent.TotalShips - opponent.DestroyedShips != 0)
                    return;

                State = new GameFinished
                {
                    Winner = CurrentPlayer,
                    Loser = opponent
                };

                Console.WriteLine($"{CurrentPlayer.Name} has vanquished {opponent.Name} by sinking all their battleships!");
                Console.WriteLine($"{CurrentPlayer.Name} has {CurrentPlayer.TotalShips - CurrentPlayer.DestroyedShips} of {CurrentPlayer.TotalShips} ships left");
            }
        }

        private void EndTurn()
        {            
            CurrentPlayer = CurrentPlayer == Player1
                ? Player2
                : Player1;
        }
    }
}