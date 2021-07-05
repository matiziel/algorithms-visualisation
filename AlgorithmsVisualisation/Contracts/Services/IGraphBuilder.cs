using System.Collections.Generic;
using Contracts.DataTransferObjects;
using GraphsAlgorithms.GraphModel;

namespace Contracts.Services {
    public interface IGraphBuilder {
        Graph BuildGraphFromGrid(List<List<int>> grid);
    }
}