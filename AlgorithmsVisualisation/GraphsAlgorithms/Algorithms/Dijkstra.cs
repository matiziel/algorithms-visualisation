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
            int pathLength = 0;
            int visitedVertices = 0;

            var distances = GetDistances();
            var priorityQueue = GetPriorityQueue(distances);

            var cameFrom = new Dictionary<int, int>();

            while (priorityQueue.Count > 0) {
                var current = priorityQueue.Dequeue();

                if (current.Index == _endIndex) {
                    var path = cameFrom.ReconstructPath(_startIndex, current.Index);
                    pathLength = path.Count;
                    frames.AddPathFrame(_graph, path);
                    break;
                }

                if (current.IsVisited())
                    continue;

                current.Visit();
                ++visitedVertices;

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

                        if (neighborIndex != _endIndex)
                            frame.AddOpenSetVertexFrameElement(neighbor);
                    }
                }
                frames.Add(frame);
            }
            return new AlgorithmResult() {
                Frames = frames,
                PathLength = pathLength,
                VisitedVertices = visitedVertices
            };
        }

        private List<float> GetDistances() {
            var distances = new List<float>(_graph.Count);
            for (int i = 0; i < _graph.Count; i++) {
                distances.Add(float.MaxValue);
            }
            distances[_startIndex] = 0;
            return distances;
        }

        private FastPriorityQueue<Vertex> GetPriorityQueue(List<float> distances) {
            var priorityQueue = new FastPriorityQueue<Vertex>(_graph.Count);

            foreach (var vertex in _graph) {
                priorityQueue.Enqueue(vertex, distances[vertex.Index]);
            }
            return priorityQueue;
        }
    }
}