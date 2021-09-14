using Contracts.DataTransferObjects;
using Common;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace UnitTests {
    public class TestGridBuilder {
        public static Grid GraphType_0(AlgorithmType algorithm, MetricType metric) {
            var gridString = @"[[5,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,6]]";

            var grid = new Grid() {
                GridArray = JsonConvert.DeserializeObject<List<List<int>>>(gridString),
                Start = 0,
                End = 63,
                AlgorithmType = algorithm,
                MetricType = metric,
                Speed = 1
            };

            return grid;
        }

        public static Grid GraphType_1(AlgorithmType algorithm, MetricType metric) {
            var gridString = @"[[0,0,0,5,0,0,0,0],[0,1,1,1,1,1,1,0],
            [0,1,0,0,0,0,1,0],[0,1,0,0,0,0,1,0],
            [0,1,0,0,0,0,1,0],[0,1,0,0,0,0,1,0],
            [0,1,0,0,0,0,1,0],[0,0,0,6,0,0,0,0]]";

            var grid = new Grid() {
                GridArray = JsonConvert.DeserializeObject<List<List<int>>>(gridString),
                Start = 3,
                End = 59,
                AlgorithmType = algorithm,
                MetricType = metric,
                Speed = 1
            };

            return grid;
        }

        public static Grid GraphType_2(AlgorithmType algorithm, MetricType metric) {
            var gridString = @"[[5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6]]";

            var grid = new Grid() {
                GridArray = JsonConvert.DeserializeObject<List<List<int>>>(gridString),
                Start = 0,
                End = 255,
                AlgorithmType = algorithm,
                MetricType = metric,
                Speed = 1
            };

            return grid;
        }

        public static Grid GraphType_3(AlgorithmType algorithm, MetricType metric) {
            var gridString = @"[[0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0],[4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
                [4,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0],[0,0,1,2,4,4,0,0,0,0,0,0,0,1,0,0],
                [0,0,1,4,2,4,4,0,0,0,0,0,0,1,0,0],[0,0,1,4,4,2,4,4,0,0,0,0,0,1,0,0],
                [0,0,1,0,4,4,2,4,4,0,0,0,0,1,0,0],[0,0,1,0,0,4,4,2,4,4,0,0,0,1,0,0],
                [0,0,1,0,0,0,4,4,2,4,4,0,0,1,0,0],[0,0,1,0,0,0,0,4,4,2,4,4,0,1,0,0],
                [0,0,1,0,0,0,0,0,4,4,2,4,4,1,0,0],[0,0,1,0,0,0,0,0,0,4,4,2,4,1,0,0],
                [0,0,1,0,0,0,0,0,0,0,4,4,2,1,0,0],[0,0,0,0,0,0,6,0,0,0,0,4,4,2,0,4],
                [0,0,0,0,0,0,0,0,0,0,0,0,4,4,0,4],[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]]";

            var grid = new Grid() {
                GridArray = JsonConvert.DeserializeObject<List<List<int>>>(gridString),
                Start = 6,
                End = 214,
                AlgorithmType = algorithm,
                MetricType = metric,
                Speed = 1
            };

            return grid;
        }
    }
}
