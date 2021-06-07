using System;
using System.Collections.Generic;
using Common;

namespace Contracts.DataTransferObjects {
    public class Grid {
        public List<List<int>> GridArray { get; set; }

        public Dictionary<int, double> GetVertexEdges(int x, int y) {
            Dictionary<int, double> edges = new();
            if ((GridElementState)GridArray[x][y] == GridElementState.Disabled)
                throw new ArgumentException("Cannot add edges to disabled vertex");

            int width = GridArray.Count;
            int height = GridArray[0].Count;

            if (x == 0) {
                if (y == 0) {
                    AddEdge(edges, x + 1, y, 1.0);
                    AddEdge(edges, x, y + 1, 1.0);
                    AddEdge(edges, x + 1, y + 1, Math.Sqrt(2));
                }
                else if (y == height - 1) {
                    AddEdge(edges, x + 1, y, 1.0);
                    AddEdge(edges, x, y - 1, 1.0);
                    AddEdge(edges, x + 1, y - 1, Math.Sqrt(2));
                }
                else {
                    AddEdge(edges, x, y + 1, 1.0);
                    AddEdge(edges, x, y - 1, 1.0);
                    AddEdge(edges, x + 1, y, 1.0);
                    AddEdge(edges, x + 1, y - 1, Math.Sqrt(2));
                    AddEdge(edges, x + 1, y + 1, Math.Sqrt(2));

                }
            }
            else if (x == width - 1) {
                if (y == 0) {
                    AddEdge(edges, x - 1, y, 1.0);
                    AddEdge(edges, x, y + 1, 1.0);
                    AddEdge(edges, x - 1, y + 1, Math.Sqrt(2));
                }
                else if (y == height - 1) {
                    AddEdge(edges, x - 1, y, 1.0);
                    AddEdge(edges, x, y - 1, 1.0);
                    AddEdge(edges, x - 1, y - 1, Math.Sqrt(2));
                }
                else {
                    AddEdge(edges, x, y + 1, 1.0);
                    AddEdge(edges, x, y - 1, 1.0);
                    AddEdge(edges, x - 1, y, 1.0);
                    AddEdge(edges, x - 1, y - 1, Math.Sqrt(2));
                    AddEdge(edges, x - 1, y + 1, Math.Sqrt(2));
                }
            }
            else if (y == 0) {
                AddEdge(edges, x, y + 1, 1.0);
                AddEdge(edges, x - 1, y, 1.0);
                AddEdge(edges, x + 1, y, 1.0);
                AddEdge(edges, x - 1, y + 1, Math.Sqrt(2));
                AddEdge(edges, x + 1, y + 1, Math.Sqrt(2));
            }
            else if (y == height - 1) {
                AddEdge(edges, x, y - 1, 1.0);
                AddEdge(edges, x - 1, y, 1.0);
                AddEdge(edges, x + 1, y, 1.0);
                AddEdge(edges, x - 1, y - 1, Math.Sqrt(2));
                AddEdge(edges, x + 1, y - 1, Math.Sqrt(2));
            }
            else {
                AddEdge(edges, x + 1, y, 1.0);
                AddEdge(edges, x + 1, y - 1, Math.Sqrt(2));
                AddEdge(edges, x + 1, y + 1, Math.Sqrt(2));

                AddEdge(edges, x - 1, y, 1.0);
                AddEdge(edges, x - 1, y - 1, Math.Sqrt(2));
                AddEdge(edges, x - 1, y + 1, Math.Sqrt(2));

                AddEdge(edges, x, y - 1, 1.0);
                AddEdge(edges, x, y + 1, 1.0);


            }
            return edges;
        }
        private void AddEdge(Dictionary<int, double> edges, int x, int y, double value) {
            if ((GridElementState)GridArray[x][y] != GridElementState.Disabled)
                edges.Add(CalculateIndex(x, y), value);
        }
        private static int CalculateIndex(int x, int y) {
            return x * y + y;
        }
    }
}