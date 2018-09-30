using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line_Algorithm
{
    public class XScan : IPolygon
    {
        public IEnumerable<Point> GetPoints(IEnumerable<Point> points)
        {
            List<Point> pointList = new List<Point>();
            int maxY = points.Max(en => en.Y);//后续用非自带方法
            int minY = points.Min(en => en.Y);
            var lines = GetLines(points.ToList());
            for(int Y = minY; Y <= maxY; Y++)
            {
                var iPoints = Intersection(Y, lines);
                //排序不是重点，先用C#的排序
                iPoints = iPoints.OrderBy(en => en.X).ToList();
                if (iPoints.Count != 0)
                {
                    for (int i = 0; i < iPoints.Count; i += 2)
                    {
                        for (int l = iPoints[i].X; l <= iPoints[i + 1].X; l++)
                        {
                            Point p = new Point()
                            {
                                X = l,
                                Y = Y,
                            };
                            pointList.Add(p);
                        }
                    }
                }
            }
            return pointList;
        }
        
        void SortPoint(List<Point> points)
        {

        }
        List<Point> Intersection(int Y, List<Line> lines)
        {
            List<Point> points = new List<Point>();
            for(int i=0;i<lines.Count;i++)
            {
                int now = i;
                int next = (i + 1) % lines.Count;
                int previous = i - 1;
                if (previous < 0)
                {
                    previous += 6;
                }
                if ((Y < lines[now].StartY && Y < lines[now].EndY) || (Y > lines[now].StartY && Y > lines[now].EndY))
                {
                    continue;
                }
                if (lines[i].A == 0)
                {
                    if (Y == lines[i].StartY)
                    {
                        for(int l = lines[i].StartX; i <= lines[i].EndY; i++)
                        {
                            Point point = new Point
                            {
                                X = l,
                                Y = Y
                            };
                            points.Add(point);
                        }
                        return points;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if(Y==lines[i].EndY)
                    {
                       
                    }
                    else if (Y == lines[i].StartY)
                    {
                        if (Y < lines[now].EndY)
                        {
                            Point point = new Point()
                            {
                                X = lines[now].StartX,
                                Y = lines[now].StartY
                            };
                            points.Add(point);
                        }
                        if (Y < lines[previous].StartY)
                        {
                            Point point = new Point()
                            {
                                X = lines[now].StartX,
                                Y = lines[now].StartY
                            };
                            points.Add(point);
                        }
                    }
                    else
                    {
                        int x = (int)((-lines[now].B * Y - lines[now].C) / lines[now].A);
                        Point point = new Point()
                        {
                            X=x,
                            Y=Y
                        };
                        points.Add(point);
                    }
                }
            }
            return points;
        }
        List<Line> GetLines(List<Point> polygon)
        {
            List<Line> lines = new List<Line>();
            for(int i = 0; i < polygon.Count; i++)
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
                lines.Add(line);
            }
            return lines;
        }
    }
}
