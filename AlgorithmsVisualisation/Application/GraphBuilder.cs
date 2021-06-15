using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Contracts.DataTransferObjects;
using Contracts.Services;
using GraphsAlgorithms.GraphModel;
using Contracts.Extensions;

namespace Application {
    public class GraphBuilder : IGraphBuilder {
        public Graph BuildGraphFromGrid(Grid grid) {
            if (grid.GridArray.Count == 0)
                throw new ArgumentException("Grid cannot be empty");
            int width = grid.GridArray.Count;
            int height = grid.GridArray[0].Count;
            List<Vertex> adjacencyList = new(grid.GridArray.Count);
            for (int x = 0; x < width; ++x) {
                for (int y = 0; y < height; ++y) {
                    if (!Enum.IsDefined(typeof(GridElementState), grid.GridArray[x][y]))
                        throw new ArgumentException("Grid element has incorrect state value");

                    var vertex = new Vertex(x * height + y, x, y);
                    if (!CheckIfDisabled(grid.GridArray[x][y])) {
                        vertex.FillEdges(grid.GetVertexEdges(x, y));
                    }
                    adjacencyList.Add(vertex);
                }
            }

            return new Graph(adjacencyList);
        }
        private static bool CheckIfDisabled(int value) =>
            (GridElementState)value == GridElementState.Disabled;
    }
}