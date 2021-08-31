using Contracts.DataTransferObjects;
using GraphsAlgorithms.Algorithms;

namespace Contracts.Services {
    public interface IAlgorithmFactory {
        public IPathFindingAlgorithm Create(Grid grid);
    }
}