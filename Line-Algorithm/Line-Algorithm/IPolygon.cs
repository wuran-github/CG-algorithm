using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line_Algorithm
{
    public interface IPolygon
    {
        IEnumerable<Point> GetPoints(IEnumerable<Point> points);
    }
}
