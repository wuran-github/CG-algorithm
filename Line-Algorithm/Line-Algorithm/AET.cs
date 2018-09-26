using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line_Algorithm
{
    public class AET
    {
        public int X { get; set; }
        public decimal DeltaX { get; set; }
        public int MaxY { get; set; }
        public AET Next { get; set; } = null;
    }
}
