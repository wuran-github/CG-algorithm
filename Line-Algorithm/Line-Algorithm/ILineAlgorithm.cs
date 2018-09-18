using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line_Algorithm
{
    public interface ILineAlgorithm
    {
        IEnumerable<Point> GetPoints(Point startPoint, Point endPoint);
    }
}
