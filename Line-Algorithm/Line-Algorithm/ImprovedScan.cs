using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line_Algorithm
{
    public struct NETList
    {
        public int X { get; set; }
        public NET NET { get; set; }
    }
    public class ImprovedScan : IPolygon
    {
        public IEnumerable<Point> GetPoints(IEnumerable<Point> points)
        {
            List<Point> pointList = new List<Point>();
            int maxY = points.Max(en => en.Y);//后续用非自带方法
            int minY = points.Min(en => en.Y);
            NET net = new NET();
            var lines = GetLines(points.ToList());
            Dictionary<int, NET> dictNET = new Dictionary<int, NET>();
            for (int Y = minY; Y <= maxY; Y++)
            {
                dictNET.Add(Y, null);
                
                foreach (var line in lines)
                {
                    if (line.StartY == Y)
                    {
                        NET newNET = new NET();
                        if (line.StartY > line.EndY)
                        {
                            newNET.MaxY = line.StartY;
                        }
                        else
                        {
                            newNET.MaxY = line.EndY;
                        }
                        
                        if (dictNET[Y] == null)
                        {
                            dictNET[Y] = newNET;
                        }
                        else
                        {
                            InsertNext(dictNET[Y], newNET);
                        }
                    }
                }
            }
            return null;
        }

        void InsertNext(NET origin,NET newNET)
        {
            while(origin.Next == null)
            {
                origin = origin.Next;
            }
             origin.Next = newNET;
          
        }
        List<Line> GetLines(List<Point> polygon)
        {
            List<Line> lines = new List<Line>();
            for (int i = 0; i < polygon.Count; i++)
            {
                Line line = new Line();
                int now = i;
                int next = (i + 1) % polygon.Count;
                var y1 = polygon[now].Y;
                var x1 = polygon[now].X;
                var y2 = polygon[next].Y;
                var x2 = polygon[next].X;

                line.StartX = x1;
                line.StartY = y1;
                line.EndX = x2;
                line.EndY = y2;

                int A = y1 - y2;
                int B = x2 - x1;
                int C = x1 * y2 - x2 * y1;
                line.A = A;
                line.B = B;
                line.C = C;
            }
            return lines;
        }
    }
}
