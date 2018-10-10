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
        public int MinX { get; set; }
        public decimal DeltaX { get; set; }
        //增加该字段用于排序
        public int MaxX { get; set; }
        public NET Next { get; set; } = null;
    }
}
