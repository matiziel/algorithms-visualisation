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

        public Dictionary<int, float> GetVertexEdges(int x, int y, float diagonalDistance) {
            Dictionary<int, float> edges = new();
            if ((GridElementState)_gridArray[x][y] == GridElementState.Disabled)
                throw new ArgumentException("Cannot add edges to disabled vertex");

            int width = _gridArray.Count;
            int height = _gridArray[0].Count;

            var straightdistance = 1.0f;

            if (x == 0) {
                if (y == 0) {
                    AddEdge(edges, x + 1, y, straightdistance);
                    AddEdge(edges, x, y + 1, straightdistance);
                    AddEdge(edges, x + 1, y + 1, diagonalDistance);
                }
                else if (y == height - 1) {
                    AddEdge(edges, x + 1, y, straightdistance);
                    AddEdge(edges, x, y - 1, straightdistance);
                    AddEdge(edges, x + 1, y - 1, diagonalDistance);
                }
                else {
                    AddEdge(edges, x, y + 1, straightdistance);
                    AddEdge(edges, x, y - 1, straightdistance);
                    AddEdge(edges, x + 1, y, straightdistance);
                    AddEdge(edges, x + 1, y - 1, diagonalDistance);
                    AddEdge(edges, x + 1, y + 1, diagonalDistance);

                }
            }
            else if (x == width - 1) {
                if (y == 0) {
                    AddEdge(edges, x - 1, y, straightdistance);
                    AddEdge(edges, x, y + 1, straightdistance);
                    AddEdge(edges, x - 1, y + 1, diagonalDistance);
                }
                else if (y == height - 1) {
                    AddEdge(edges, x - 1, y, straightdistance);
                    AddEdge(edges, x, y - 1, straightdistance);
                    AddEdge(edges, x - 1, y - 1, diagonalDistance);
                }
                else {
                    AddEdge(edges, x, y + 1, straightdistance);
                    AddEdge(edges, x, y - 1, straightdistance);
                    AddEdge(edges, x - 1, y, straightdistance);
                    AddEdge(edges, x - 1, y - 1, diagonalDistance);
                    AddEdge(edges, x - 1, y + 1, diagonalDistance);
                }
            }
            else if (y == 0) {
                AddEdge(edges, x, y + 1, straightdistance);
                AddEdge(edges, x - 1, y, straightdistance);
                AddEdge(edges, x + 1, y, straightdistance);
                AddEdge(edges, x - 1, y + 1, diagonalDistance);
                AddEdge(edges, x + 1, y + 1, diagonalDistance);
            }
            else if (y == height - 1) {
                AddEdge(edges, x, y - 1, straightdistance);
                AddEdge(edges, x - 1, y, straightdistance);
                AddEdge(edges, x + 1, y, straightdistance);
                AddEdge(edges, x - 1, y - 1, diagonalDistance);
                AddEdge(edges, x + 1, y - 1, diagonalDistance);
            }
            else {
                AddEdge(edges, x + 1, y, straightdistance);
                AddEdge(edges, x + 1, y - 1, diagonalDistance);
                AddEdge(edges, x + 1, y + 1, diagonalDistance);

                AddEdge(edges, x - 1, y, straightdistance);
                AddEdge(edges, x - 1, y - 1, diagonalDistance);
                AddEdge(edges, x - 1, y + 1, diagonalDistance);

                AddEdge(edges, x, y - 1, straightdistance);
                AddEdge(edges, x, y + 1, straightdistance);
            }
            return edges;
        }
        private void AddEdge(Dictionary<int, float> edges, int x, int y, float value) {
            if ((GridElementState)_gridArray[x][y] != GridElementState.Disabled)
                edges.Add(CalculateIndex(x, y), value);
        }
        private int CalculateIndex(int x, int y) => x * Height + y;

    }
}