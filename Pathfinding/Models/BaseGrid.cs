using Pathfinding.Types;
using Pathfinding.Utilities;
using System.Collections.Generic;

namespace Pathfinding.Models
{
    public abstract class BaseGrid
    {
        public int MapSizeX { get; }
        public int MapSizeY { get; }

        public BaseGrid(int mapSizeX, int mapSizeY)
        {
            MapSizeX = mapSizeX;
            MapSizeY = mapSizeY;
        }

        public abstract bool IsWalkableAt(
            Position p,
            bool final,
            params object[] args);

        public List<Position> GetNeighbors(
            Position p,
            DiagonalMovement movement,
            Position end,
            params object[] args)
        {
            int x = p.X;
            int y = p.Y;
            List<Position> neighbors = new List<Position>();
            bool[] hasMovement = { false, false, false, false };

            for (int i = 0; i < PositionUtility.Positions.Length; i++)
            {
                Position pos = p + PositionUtility.Positions[i];

                if (IsWalkableAt(pos, pos == end, args))
                {
                    neighbors.Add(pos);
                    hasMovement[i] = true;
                }
            }

            switch (movement)
            {
                case DiagonalMovement.ALWAYS:
                    foreach (Position option in PositionUtility.DiagonalPositions)
                    {
                        Position pos = p + option;

                        if (IsWalkableAt(pos, pos == end, args))
                            neighbors.Add(pos);
                    }
                    break;

                case DiagonalMovement.ONE_WALKABLE:
                    for (int i = 0; i < PositionUtility.DiagonalPositions.Length; i++)
                    {
                        int num1 = 3 + i;
                        int num2 = 0 + i;

                        if (num1 > 3) num1 -= 4;

                        if (hasMovement[num1] || hasMovement[num2])
                        {
                            Position pos = p + PositionUtility.DiagonalPositions[i];

                            if (IsWalkableAt(pos, pos == end, args))
                                neighbors.Add(pos);
                        }
                    }
                    break;

                case DiagonalMovement.NO_OBSTACLE:
                    for (int i = 0; i < PositionUtility.DiagonalPositions.Length; i++)
                    {
                        int num1 = 3 + i;
                        int num2 = 0 + i;

                        if (num1 > 3) num1 -= 4;

                        if (hasMovement[num1] && hasMovement[num2])
                        {
                            Position pos = p + PositionUtility.DiagonalPositions[i];

                            if (IsWalkableAt(pos, pos == end, args))
                                neighbors.Add(pos);
                        }
                    }
                    break;
            }

            return neighbors;
        }
    }
}