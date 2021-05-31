using System.Collections.Generic;

namespace GraphsAlgorithms.Graph {
    public class Vertex {
        public int Index { get; }
        public int X { get; }
        public int Y { get; }
        public VertexState State { get; set; }
        public Dictionary<int, int> Edges { get; }
        public Vertex(int index, int x, int y, Dictionary<int, int> edges) {
            Index = index;
            State = VertexState.Unvisited;
            Edges = edges;
            X = x;
            Y = y;
        }
    }
}