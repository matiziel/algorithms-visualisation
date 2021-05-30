using System.Collections.Generic;

namespace GraphsAlgorithms.Graph {
    public class Vertex {
        public int Index { get; }
        public VertexState State { get; set; }
        public Dictionary<int, int> Edges { get; }
        public Vertex(int index, Dictionary<int, int> edges) {
            Index = index;
            State = VertexState.Unvisited;
            Edges = edges;
        }
    }
}