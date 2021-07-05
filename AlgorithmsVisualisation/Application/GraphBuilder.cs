using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Contracts.DataTransferObjects;
using Contracts.Services;
using GraphsAlgorithms.GraphModel;
using Contracts.Extensions;
using Application.Models;

namespace Application {
    public class GraphBuilder : IGraphBuilder {
        public Graph BuildGraphFromGrid(List<List<int>> grid) {
            if (grid.Count == 0)
                throw new ArgumentException("Grid cannot be empty");

            var gridModel = new GridModel(grid);

            List<Vertex> adjacencyList = new(gridModel.Width * gridModel.Height);

            for (int x = 0; x < gridModel.Width; ++x) {
                for (int y = 0; y < gridModel.Height; ++y) {
                    if (!Enum.IsDefined(typeof(GridElementState), gridModel[x, y]))
                        throw new ArgumentException("Grid element has incorrect state value");

                    var vertex = new Vertex(x * gridModel.Height + y, x, y);
                    if (!CheckIfDisabled(gridModel[x, y])) {
                        vertex.FillEdges(gridModel.GetVertexEdges(x, y));
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