using System.Collections.Generic;

namespace Contracts.DataTransferObjects {
    public class Animation {
        public List<List<List<int>>> Frames { get; set; }
        public double Time { get; set; }
    }
}