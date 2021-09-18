using Contracts.DataTransferObjects;
using GraphsAlgorithms.Algorithms;

namespace Contracts.Services {
    public interface IAlgorithmFactory {
        IPathFindingAlgorithm Create(Grid grid);
    }
}
