using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line_Algorithm
{
    class XScan : IPolygon
    {
        public IEnumerable<Point> GetPoints(IEnumerable<Point> points)
        {
            List<Point> pointList = null;
            int maxY = points.Max(en => en.Y);//后续用非自带方法
            int minY = points.Min(en => en.Y);

            return pointList;
        }
    }
}
