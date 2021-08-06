using System;
using System.Collections.Generic;
using Common;
using System.Linq;

namespace Contracts.DataTransferObjects {
    public class Grid {
        public List<List<int>> GridArray { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public MetricType MetricType { get; set; }
        public AlgorithmType AlgorithmType { get; set; }
    }
}