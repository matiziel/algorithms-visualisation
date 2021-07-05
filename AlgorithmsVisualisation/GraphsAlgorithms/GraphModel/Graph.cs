using System.Collections;
using System.Collections.Generic;

namespace GraphsAlgorithms.GraphModel {
    public class Graph : IEnumerable<Vertex> {
        private readonly List<Vertex> _adjacencyList;
        public Graph(List<Vertex> adjacencyList) {
            _adjacencyList = adjacencyList;
        }
        public Vertex this[int index] => _adjacencyList[index];

        public int Count => _adjacencyList.Count;

        #region IEnumerableImplementation

        public IEnumerator<Vertex> GetEnumerator() {
            return _adjacencyList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion
    }
}