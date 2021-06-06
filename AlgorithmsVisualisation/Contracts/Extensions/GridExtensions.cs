using System.Collections.Generic;
using Contracts.DataTransferObjects;

namespace Contracts.Extensions {
    public static class GridExtensions {
        public static Dictionary<int, double> GetVertexEdges(this Grid grid, int x, int y) {
            Dictionary<int, double> edges = new();
            int index = x * y + y;
            return edges;
        }
    }
}