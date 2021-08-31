using System.Collections.Generic;
using Priority_Queue;

namespace GraphsAlgorithms.GraphModel {
    public class Vertex : FastPriorityQueueNode {
        public int Index { get; }
        public int X { get; }
        public int Y { get; }
        public VertexState State { get; private set; }
        public Dictionary<int, float> Edges { get; private set; }
        public Vertex(int index, int x, int y) {
            Index = index;
            State = VertexState.Unvisited;
            X = x;
            Y = y;
        }
        public void FillEdges(Dictionary<int, float> edges) {
            Edges = edges;
        }
        public bool IsVisited()
            => State == VertexState.Visited;
        public void Visit()
            => State = VertexState.Visited;
    }
}