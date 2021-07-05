using System;
using System.Collections.Generic;
using Common;

namespace Application.Models {
    public class GridModel {
        private readonly List<List<int>> _gridArray;

        public GridModel(List<List<int>> gridArray) {

            _gridArray = gridArray;
        }

        public int Height => _gridArray[0].Count;

        public int Width => _gridArray.Count;

        public int this[int x, int y] => _gridArray[x][y];

        public Dictionary<int, double> GetVertexEdges(int x, int y) {
            Dictionary<int, double> edges = new();
            if ((GridElementState)_gridArray[x][y] == GridElementState.Disabled)
                throw new ArgumentException("Cannot add edges to disabled vertex");

            int width = _gridArray.Count;
            int height = _gridArray[0].Count;

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
            if ((GridElementState)_gridArray[x][y] != GridElementState.Disabled)
                edges.Add(CalculateIndex(x, y), value);
        }
        private int CalculateIndex(int x, int y) {
            int height = _gridArray[0].Count;
            return x * height + y;
        }
    }
}