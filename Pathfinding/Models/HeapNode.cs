namespace Pathfinding.Models
{
    internal class HeapNode
    {
        public Position Position { get; }
        public float ExpectedCost { get; set; }
        public HeapNode Next { get; set; }

        internal HeapNode(Position position, float expectedCost)
        {
            Position = position;
            ExpectedCost = expectedCost;
        }
    }
}
