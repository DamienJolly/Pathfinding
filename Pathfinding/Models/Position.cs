using System;

namespace Pathfinding.Models
{
    public class Position : IEquatable<Position>
    {
        private const float DiagonalCost = 1.4142135623730950488016887242097f;
        private const float LateralCost = 1.0f;

        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object other)
        {
            if (other is Position position)
            {
                return position.Equals(this);
            }

            return false;
        }

        public bool Equals(Position other)
        {
            return (X == other.X && Y == other.Y);
        }

        public static bool operator ==(Position first, Position compare)
        {
            return first.Equals(compare);
        }

        public static bool operator !=(Position first, Position compare)
        {
            return !first.Equals(compare);
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public float Cost =>
            (X != 0 && Y != 0) ? DiagonalCost : LateralCost;
    }
}
