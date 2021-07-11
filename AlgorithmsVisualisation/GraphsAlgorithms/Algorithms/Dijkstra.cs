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

            var cameFrom = new Dictionary<int, int>();

            while (priorityQueue.Count > 0) {
                var current = priorityQueue.Dequeue();

                if (current.Index == _endIndex) {
                    frames.AddPathFrame(_graph, cameFrom.ReconstructPath(_startIndex, current.Index));
                    break;
                }

                if (current.IsVisited())
                    continue;

                current.Visit();

                var frame = new Frame() {
                    FrameElements = new List<FrameElement>()
                };
                if (current.Index != _startIndex)
                    frame.AddVisitedVertexFrameElement(current);


                foreach (int neighborIndex in current.Edges.Keys) {
                    var neighbor = _graph[neighborIndex];

                    if (neighbor.IsVisited())
                        continue;

                    var tmp = distances[current.Index] + current.Edges[neighborIndex];
                    if (tmp < distances[neighborIndex]) {
                        cameFrom[neighborIndex] = current.Index;

                        distances[neighborIndex] = tmp;
                        priorityQueue.UpdatePriority(neighbor, distances[neighborIndex]);
                    }
                    if (neighborIndex != _endIndex)
                        frame.AddOpenSetVertexFrameElement(neighbor);
                }

                frames.Add(frame);
            }
            return new AlgorithmResult() {
                Frames = frames
            };
        }

        private List<double> GetDistances() {
            var distances = new List<double>(_graph.Count);
            for (int i = 0; i < _graph.Count; i++) {
                distances.Add(double.MaxValue);
            }
            distances[_startIndex] = 0;
            return distances;
        }

        private SimplePriorityQueue<Vertex, double> GetPriorityQueue(List<double> distances) {
            var priorityQueue = new SimplePriorityQueue<Vertex, double>();

            foreach (var vertex in _graph) {
                priorityQueue.Enqueue(vertex, distances[vertex.Index]);
            }
            return priorityQueue;
        }
    }
}