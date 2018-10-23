using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line_Algorithm
{
    public class DDA:ILineAlgorithm
    {
        public IEnumerable<Point> GetPoints(Point startPoint,Point endPoint)
        {
            List<Point> points = new List<Point>();
            if(startPoint!=null && endPoint != null)
            {
                if (startPoint.X > endPoint.X)
                {
                    var tempPoint = startPoint;
                    startPoint = endPoint;
                    endPoint = tempPoint;
                }
                if (startPoint.X != endPoint.X) {
                    decimal k =(decimal)((endPoint.Y - startPoint.Y+0.0)/(endPoint.X - startPoint.X+0.0));
                    if (Math.Abs(k) < 1)
                    {
                        points = LTOne(k, startPoint, endPoint);
                    }
                    else
                    {
                        points = GTOne(k, startPoint, endPoint);
                    }
                 }
            }
            return points;
        }
        private List<Point> LTOne(decimal k, Point startPoint, Point endPoint)
        {
            List<Point> points = new List<Point>();
            if (k > 0)
            {
                var p = startPoint;
                points.Add(p);
                while (true)
                {
                    if (p.X < endPoint.X - 1)
                    {
                        var newPoint = GetNextPointByX(p, k);
                        points.Add(newPoint);
                        p = newPoint;
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
                var p = endPoint;
                points.Add(p);
                while (true)
                {
                    if (p.X > startPoint.X +1)
                    {
                        var newPoint = MinusGetNextPointByX(p, k);
                        points.Add(newPoint);
                        p = newPoint;
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
        private List<Point> GTOne(decimal k, Point startPoint, Point endPoint)
        {
            k =1 / k;
            List<Point> points = new List<Point>();
            if (k > 0)
            {
                var p = startPoint;
                points.Add(p);
                while (true)
                {
                    if (p.Y < endPoint.Y - 1)
                    {
                        var newPoint = GetNextPointByY(p, k);
                        points.Add(newPoint);
                        p = newPoint;
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
                var p = endPoint;
                points.Add(p);
                while (true)
                {
                    if (p.Y < startPoint.Y + 1)
                    {
                        var newPoint = MinusGetNextPointByY(p, k);
                        points.Add(newPoint);
                        p = newPoint;
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
        private Point GetNextPointByX(Point nowPoint, decimal k)
        {
            Point p = new Point();
            p.X = nowPoint.X + 1;
            p.RealX = p.X;
            p.RealY = nowPoint.RealY + k;
            p.Y = (int)(p.RealY + 0.5m);
            return p;
        }
        private Point MinusGetNextPointByX(Point nowPoint,decimal k)
        {
            Point p = new Point();
            p.X = nowPoint.X - 1;
            p.RealX = p.X;
            p.RealY = nowPoint.RealY - k;
            p.Y = (int)(p.RealY + 0.5m);
            return p;
        }
        private Point GetNextPointByY(Point nowPoint,decimal k)
        {
            Point p = new Point();
            p.Y = nowPoint.Y + 1;
            p.RealY = p.Y;
            p.RealX = nowPoint.RealX + k;
            p.X = (int)(p.RealX + 0.5m);
            return p;
        }
        private Point MinusGetNextPointByY(Point nowPoint, decimal k)
        {
            Point p = new Point();
            p.Y = nowPoint.Y - 1;
            p.RealY = p.Y;
            p.RealX = nowPoint.RealX - k;
            p.X = (int)(p.RealX + 0.5m);
            return p;
        }
    }
}
