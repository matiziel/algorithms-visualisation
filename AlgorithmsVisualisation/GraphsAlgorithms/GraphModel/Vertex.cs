using System.Collections.Generic;

namespace GraphsAlgorithms.GraphModel {
    public class Vertex {
        public int Index { get; }
        public int X { get; }
        public int Y { get; }
        public VertexState State { get; set; }
        public Dictionary<int, int> Edges { get; private set;}
        public Vertex(int index, int x, int y) {
            Index = index;
            State = VertexState.Unvisited;
            Edges = new Dictionary<int, int>();
            X = x;
            Y = y;
        }
    }
}