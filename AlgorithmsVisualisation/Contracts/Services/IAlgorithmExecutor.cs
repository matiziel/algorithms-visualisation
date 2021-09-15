using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Contracts.DataTransferObjects;
using GraphsAlgorithms.Result;

namespace Contracts.Services {
    public interface IAlgorithmExecutor {
        Task<Animation> Execute(Grid grid);
        Task<IEnumerable<TestResult>> TestExecute(Grid grid, int testCount);
    }
}