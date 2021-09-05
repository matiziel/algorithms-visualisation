using System.Collections.Generic;
using Common;
using Contracts.DataTransferObjects;
using GraphsAlgorithms.Result;

namespace Contracts.Services {
    public interface IAlgorithmExecutor {
        Animation Execute(Grid grid);
        IEnumerable<TestResult> TestAlgorithmsExecute(Grid grid, int testCount);
        IEnumerable<TestResult> TestMetricsExecute(Grid grid, int testCount);
    }
}