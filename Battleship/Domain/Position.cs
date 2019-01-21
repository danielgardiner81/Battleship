namespace Battleship.Domain
{
    public struct Position
    {
        public Position(int x, int y)
        {
            Y = y;
            X = x;
        }

        public int X;
        public int Y;

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
    }
}