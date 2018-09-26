using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line_Algorithm
{
    public class NET
    {
        public int MaxY { get; set; }
        public decimal MinX { get; set; }
        public int DeltaX { get; set; }
        public NET Next { get; set; } = null;
    }
}
