using System.Collections.Generic;

namespace GraphsAlgorithms.GraphModel {
    public class Vertex {
        public int Index { get; }
        public int X { get; }
        public int Y { get; }
        public VertexState State { get; set; }
        public Dictionary<int, double> Edges { get; private set; }
        public Vertex(int index, int x, int y) {
            Index = index;
            State = VertexState.Unvisited;
            X = x;
            Y = y;
        }
        public void FillEdges(Dictionary<int, double> edges) {
            Edges = edges;
        }
    }
}