namespace Battleship.Domain
{
    public class Board
    {
        private Size Size => new Size {Width = 10, Height = 10};

        public bool IsWithinBounds(Position position, (int Right, int Bottom) shipBounds)
        {
            if (position.X < 0 || position.Y < 0)
                return false;

            if (shipBounds.Right > Size.Width || shipBounds.Bottom > Size.Height)
                return false;

            return true;
        }
    }
}