using Contracts.Services;

namespace Application {
    public class AlgorithmExecutor {
        private readonly IAlgorithmFactory _factory;
        private readonly IGraphBuilder _builder;

        public AlgorithmExecutor(IAlgorithmFactory factory, IGraphBuilder builder) {
            _factory = factory;
            _builder = builder;
        }

    }
}