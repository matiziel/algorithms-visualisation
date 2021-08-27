using System;
using System.Collections.Generic;
using Common;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Contracts.DataTransferObjects.Validation;

namespace Contracts.DataTransferObjects {
    public class Grid {
        [Required]
        public List<List<int>> GridArray { get; set; }

        [Range(0, int.MaxValue)]
        public int Start { get; set; }

        [Range(0, int.MaxValue)]
        public int End { get; set; }

        [AllowedMetricType]
        public MetricType MetricType { get; set; }

        [AllowedAlgorithmType]
        public AlgorithmType AlgorithmType { get; set; }

        [Range(1, 8)]
        public int Speed { get; set; }

    }
}