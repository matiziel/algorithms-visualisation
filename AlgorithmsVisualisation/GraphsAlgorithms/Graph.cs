using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphsAlgorithms {
    public class Graph {
        public readonly List<List<int>> AdjacencyList;
        public Graph(List<List<int>> adjacencyList) {
            AdjacencyList = adjacencyList; 
        }
    }
}
