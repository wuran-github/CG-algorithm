using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line_Algorithm
{
    public class Center : ILineAlgorithm
    {
        public IEnumerable<Point> GetPoints(Point startPoint, Point endPoint)
        {
            List<Point> points = new List<Point>();
            if (startPoint != null && endPoint != null)
            {
                if (startPoint.X != endPoint.X)
                {
                    decimal k = (decimal)((endPoint.Y - startPoint.Y + 0.0) / (endPoint.X - startPoint.X + 0.0));
                    int A = startPoint.Y - endPoint.Y;
                    int B = endPoint.X - startPoint.X;
                    int C = startPoint.X * endPoint.Y - endPoint.X * startPoint.Y;

                    if (Math.Abs(k) < 1)
                    {
                        points = LTOne(k,A,B,C, startPoint, endPoint);
                    }
                    else
                    {
                        points = GTOne(k,A,B,C, startPoint, endPoint);
                    }
                }
            }
            return points;
        }
        private List<Point> LTOne(decimal k, int A, int B, int C, Point startPoint, Point endPoint)
        {
            List<Point> points = new List<Point>();
            int step = 1;
            if (k > 0)
            {
                var p = startPoint;
                points.Add(p);
                var d=2*A+B;
                while (true)
                {
                    if (p.X < endPoint.X - 1)
                    {
                        
                        var newPoint = GetNextPointByX(p, d,step);
                        points.Add(newPoint);
                        p = newPoint;
                        if (d < 0)
                        {
                            d = d + 2 * A + 2 * B;
                        }
                        else
                        {
                            d = d + 2 * A;
                        }
                    }
                    else
                    {
                        var newPoint = endPoint;
                        points.Add(newPoint);
                        break;
                    }
                }
            }
            else
            {
                step = -1;
                var p = endPoint;
                var d = B - 2 * A;
                points.Add(p);
                while (true)
                {
                    if (p.X > startPoint.X + 1)
                    {
                        var newPoint = GetNextPointByX(p, d, step);
                        points.Add(newPoint);
                        p = newPoint;
                        if (d < 0)
                        {
                            d = d - 2 * A + 2 * B;
                        }
                        else
                        {
                            d = d - 2 * A;
                        }
                    }
                    else
                    {
                        var newPoint = startPoint;
                        points.Add(newPoint);
                        break;
                    }
                }
            }
            return points;
        }
        private List<Point> GTOne(decimal k,int A,int B,int C, Point startPoint, Point endPoint)
        {
            k = 1 / k;
            List<Point> points = new List<Point>();
            var step = 1;
            if (k > 0)
            {
                var p = startPoint;
                points.Add(p);
                var d=A +2 * B;
                while (true)
                {
                    if (p.Y < endPoint.Y - 1)
                    {
                        var newPoint = GetNextPointByY(p, d,step);
                        points.Add(newPoint);
                        p = newPoint;
                        if (d > 0)
                        {
                            d = d + 2 * A + 2 * B;
                        }
                        else
                        {
                            d = d + 2 * B;
                        }
                    }
                    else
                    {
                        var newPoint = endPoint;
                        points.Add(newPoint);
                        break;
                    }
                }
            }
            else
            {
                var p = startPoint;
                points.Add(p);
                step = -1;
                var d = A - 2 * B;
                while (true)
                {
                    if (p.Y > endPoint.Y + 1)
                    {
                        var newPoint = GetNextPointByY(p, d,step);
                        points.Add(newPoint);
                        p = newPoint;
                        if (d < 0)
                        {
                            d = d + 2 * A - 2 * B;
                        }
                        else
                        {
                            d = d - 2 * B;
                        }
                    }
                    else
                    {
                        var newPoint = endPoint;
                        points.Add(newPoint);
                        break;
                    }
                }
            }
            return points;
        }
        private Point GetNextPointByX(Point nowPoint, int d,int step)
        {
            Point p = new Point();
            p.X = nowPoint.X + step;
            p.RealX = p.X;
            if (d < 0)
            {
                p.Y = nowPoint.Y+1;
            }
            else
            {
                p.Y = nowPoint.Y;
            }
            return p;
        }

        private Point GetNextPointByY(Point nowPoint, int d, int step)
        {
            Point p = new Point();
            p.Y = nowPoint.Y + step;
            if (step > 0)
            {
                if (d > 0)
                {
                    p.X = nowPoint.X + 1;
                }
                else
                {
                    p.X = nowPoint.X;
                }
            }
            else
            {
                if (d < 0)
                {
                    p.X = nowPoint.X + 1;
                }
                else
                {
                    p.X = nowPoint.X;
                }
            }
            return p;
        }

    }
}
