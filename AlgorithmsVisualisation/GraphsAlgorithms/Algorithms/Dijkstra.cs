using System;
using System.Collections.Generic;
using GraphsAlgorithms.Extensions;
using GraphsAlgorithms.GraphModel;
using GraphsAlgorithms.Result;
using Priority_Queue;

namespace GraphsAlgorithms.Algorithms {
    public class Dijkstra : IPathFindingAlgorithm {
        private readonly Graph _graph;
        private readonly int _startIndex;
        private readonly int _endIndex;
        public Dijkstra(Graph graph, int startIndex, int endIndex) {
            _graph = graph;
            _startIndex = startIndex;
            _endIndex = endIndex;
        }
        public AlgorithmResult Execute() {
            List<Frame> frames = new();

            var distances = GetDistances();
            var priorityQueue = GetPriorityQueue(distances);

            while (priorityQueue.Count > 0) {
                var vertex = priorityQueue.Dequeue();

                if (vertex.IsVisited())
                    continue;

                vertex.Visit();

                if (vertex.Index != _startIndex)
                    frames.AddVisitedVertexFrame(vertex);

                var frame = new Frame() {
                    FrameElements = new List<FrameElement>()
                };

                foreach (int neighborIndex in vertex.Edges.Keys) {

                    if (neighborIndex == _endIndex)
                        return new AlgorithmResult() {
                            Frames = frames
                        };
                    var tmpVertex = _graph.AdjacencyList[neighborIndex];

                    if (tmpVertex.IsVisited())
                        continue;

                    var tmp = distances[vertex.Index] + vertex.Edges[neighborIndex];
                    if (tmp < distances[neighborIndex]) {
                        distances[neighborIndex] = tmp;
                        priorityQueue.UpdatePriority(tmpVertex, distances[neighborIndex]);
                    }

                    frame.AddOpenSetVertexFrameElement(tmpVertex);
                }
                frames.Add(frame);
            }
            return new AlgorithmResult() {
                Frames = frames
            };
        }

        private List<double> GetDistances() {
            var distances = new List<double>(_graph.AdjacencyList.Count);
            for (int i = 0; i < _graph.AdjacencyList.Count; i++) {
                distances.Add(double.MaxValue);
            }
            distances[_startIndex] = 0;
            return distances;
        }

        private SimplePriorityQueue<Vertex, double> GetPriorityQueue(List<double> distances) {
            var priorityQueue = new SimplePriorityQueue<Vertex, double>();

            foreach (var vertex in _graph.AdjacencyList) {
                priorityQueue.Enqueue(vertex, distances[vertex.Index]);
            }
            return priorityQueue;
        }
    }
}