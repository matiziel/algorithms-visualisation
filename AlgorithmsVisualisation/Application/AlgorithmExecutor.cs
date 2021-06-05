using Contracts.Services;
using Contracts.DataTransferObjects.Result;

namespace Application {
    public class AlgorithmExecutor : IAlgorithmExecutor {
        private readonly IAlgorithmFactory _factory;
        private readonly IGraphBuilder _builder;

        public AlgorithmExecutor(IAlgorithmFactory factory, IGraphBuilder builder) {
            _factory = factory;
            _builder = builder;
        }

        public AlgorithmResult Execute() {
            throw new System.NotImplementedException();
        }
    }
}