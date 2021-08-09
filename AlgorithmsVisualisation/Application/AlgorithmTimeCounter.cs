using System;
using System.Diagnostics;
using Contracts.Services;
using GraphsAlgorithms.Algorithms;
using GraphsAlgorithms.Result;

namespace Application {
    public class AlgorithmTimeCounter : IPathFindingAlgorithm {

        private readonly IPathFindingAlgorithm _algorithm;

        public AlgorithmTimeCounter(IPathFindingAlgorithm algorithm) =>
            _algorithm = algorithm;

        public AlgorithmResult Execute() {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var result = _algorithm.Execute();
            stopwatch.Stop();
            result.TimeSpan = stopwatch.Elapsed;
            return result;
        }
    }
}