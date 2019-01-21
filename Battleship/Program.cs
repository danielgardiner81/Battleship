using System;
using Battleship.Domain;

namespace Battleship
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Battleship battle begin!");

            var builder = new GameBuilder();
            builder.PlaceShip(1, new Ship(2), new Position(5, 5), Orientation.Horizontal);
            builder.PlaceShip(1, new Ship(6), new Position(3, 2), Orientation.Vertical);
            builder.PlaceShip(2, new Ship(2), new Position(7, 5), Orientation.Vertical);
            var game = builder.StartGame();

            game.Attack(new Position(0, 0));
            game.Attack(new Position(5, 5));
            game.Attack(new Position(0, 0));
            game.Attack(new Position(6, 5));
            game.Attack(new Position(0, 0));
            game.Attack(new Position(3, 2));
            game.Attack(new Position(0, 0));
            game.Attack(new Position(3, 3));
            game.Attack(new Position(0, 0));
            game.Attack(new Position(3, 4));
            game.Attack(new Position(0, 0));
            game.Attack(new Position(3, 5));
            game.Attack(new Position(0, 0));
            game.Attack(new Position(3, 6));
            game.Attack(new Position(0, 0));
            game.Attack(new Position(3, 7));

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}