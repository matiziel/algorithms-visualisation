using Contracts.DataTransferObjects.Result;

namespace Contracts.Services {
    public interface IAlgorithmExecutor {
        AlgorithmResult Execute();
    }
}