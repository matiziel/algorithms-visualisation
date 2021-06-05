using System.Collections.Generic;

namespace GraphsAlgorithms.GraphModel {
    public class Graph {
        public List<Vertex> AdjacencyList { get; }
        public Graph(List<Vertex> adjacencyList) {
            AdjacencyList = adjacencyList;
        }

    }
}