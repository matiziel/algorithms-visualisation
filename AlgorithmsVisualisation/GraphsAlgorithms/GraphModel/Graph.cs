using System.Collections;
using System.Collections.Generic;
using GraphsAlgorithms.Metrics;

namespace GraphsAlgorithms.GraphModel {
    public class Graph : IEnumerable<Vertex> {
        private readonly List<Vertex> _adjacencyList;
        private readonly IMetric _metric;
        
        public Graph(List<Vertex> adjacencyList, IMetric metric) {
            _adjacencyList = adjacencyList;
            _metric = metric;
        }
        
        public Vertex this[int index] => _adjacencyList[index];

        public float GetDistance(int start, int end) =>
            _metric.GetDistance(_adjacencyList[start], _adjacencyList[end]);

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