using System;
using System.Collections.Generic;
using Common;
using GraphsAlgorithms.Extensions;
using GraphsAlgorithms.GraphModel;
using GraphsAlgorithms.Result;
using Priority_Queue;

namespace GraphsAlgorithms.Algorithms {
    public class AStar : IPathFindingAlgorithm {
        private readonly Graph _graph;
        private readonly int _startIndex;
        private readonly int _endIndex;
        public AStar(Graph graph, int startIndex, int endIndex) {
            _graph = graph;
            _startIndex = startIndex;
            _endIndex = endIndex;
        }

        public AlgorithmResult Execute() {
            List<Frame> frames = new();
            int pathLength = 0;

            var gScore = GetDistances(
                valueForStart: 0.0
            );
            var fScore = GetDistances(
                valueForStart: HeuristicFunction(_startIndex)
            );

            var cameFrom = new Dictionary<int, int>();

            var openSet = new SimplePriorityQueue<Vertex, double>();
            openSet.Enqueue(_graph[_startIndex], fScore[_startIndex]);

            while (openSet.Count > 0) {
                var current = openSet.Dequeue();

                if (current.Index == _endIndex) {
                    var path = cameFrom.ReconstructPath(_startIndex, current.Index);
                    pathLength = path.Count;
                    frames.AddPathFrame(_graph, path);
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

                    var tentativeGScore = gScore[current.Index] + current.Edges[neighborIndex];

                    if (tentativeGScore < gScore[neighborIndex]) {
                        cameFrom[neighborIndex] = current.Index;

                        gScore[neighborIndex] = tentativeGScore;
                        fScore[neighborIndex] = gScore[neighborIndex] + HeuristicFunction(neighborIndex);

                        if (openSet.Contains(neighbor))
                            openSet.UpdatePriority(neighbor, fScore[neighborIndex]);
                        else
                            openSet.Enqueue(neighbor, fScore[neighborIndex]);
                    }
                    if (neighborIndex != _endIndex)
                        frame.AddOpenSetVertexFrameElement(neighbor);
                }

                frames.Add(frame);
            }
            return new AlgorithmResult() {
                Frames = frames,
                PathLength = pathLength
            };
        }

        private List<double> GetDistances(double valueForStart) {
            var distances = new List<double>(_graph.Count);
            for (int i = 0; i < _graph.Count; i++) {
                distances.Add(double.MaxValue);
            }
            distances[_startIndex] = valueForStart;
            return distances;
        }

        private double HeuristicFunction(int start) =>
            _graph.GetDistance(start, _endIndex);
    }
}