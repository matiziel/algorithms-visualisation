using Common;
using Contracts.DataTransferObjects;
using GraphsAlgorithms.Result;

namespace Contracts.Services {
    public interface IAlgorithmExecutor {
        AlgorithmResult Execute(Grid grid, AlgorithmType type);
    }
}