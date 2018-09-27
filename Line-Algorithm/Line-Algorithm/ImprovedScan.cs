using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line_Algorithm
{

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
            AET aet = null;
            for (int Y = minY; Y <= maxY; Y++)
            {
                dictNET.Add(Y, null);
                
                foreach (var line in lines)
                {
                    if (line.StartY == Y || line.EndY == Y)
                    {
                        AddNET(line, dictNET[Y]);
                    }
                    
                }
            }
            for (int Y = minY; Y <= maxY; Y++)
            {
                if (dictNET[Y] != null)
                {
                    InsertAET(dictNET[Y], aet);
                }
                if (aet != null)
                {
                    #region 遍历得到点
                    AET left = null;
                    AET right = null;
                    left = aet;
                    right = aet.Next;
                    #endregion

                    #region 遍历删除点

                    DeleteAET(aet,Y);
                    #endregion
                }
            }

            return null;
        }
        void DeleteAET(AET aet,int Y)
        {
            AET nextAET = null;
            AET nowAET = null;
            nowAET = aet;
            nextAET = aet.Next;
            while (nowAET != null)
            {
                if (nowAET.MaxY == Y)
                {
                    if (nowAET.Equals(aet))
                    {
                        aet = nextAET;
                    }
                    else
                    {

                    }
                }
            }
        }
        void InsertAET(NET net,AET aet)
        {
            AET lastAET = null;
            AET nowAET = null;
            AET tempAET = null;
            if (net != null)
            {
                if (aet == null)
                {
                    aet = new AET
                    {
                        DeltaX = net.DeltaX,
                        MaxY = net.MaxY,
                        X = net.MinX
                    };
                }
                else
                {
                    nowAET = aet.Next;
                    lastAET = aet;
                    while (nowAET != null)
                    {
                        if (nowAET.X > net.MinX)
                        {
                            tempAET = new AET()
                            {
                                DeltaX = net.DeltaX,
                                MaxY = net.MaxY,
                                X = net.MinX,
                            };
                            lastAET.Next = tempAET;
                            tempAET.Next = nowAET;
                            break;
                        }
                        else
                        {
                            lastAET = nowAET;
                            nowAET = nowAET.Next;
                        }
                    }

                    if (tempAET == null)
                    {
                        tempAET = new AET()
                        {
                            DeltaX = net.DeltaX,
                            MaxY = net.MaxY,
                            X = net.MinX,
                        };
                        lastAET.Next = tempAET;
                    }
                }
            }
        }
        void AddNET(Line line,NET origin)
        {
            NET newNET = new NET();
            if (line.StartY > line.EndY)
            {
                newNET.MaxY = line.StartY;
                newNET.MinX = line.EndX;
                newNET.DeltaX = line.ReciprocalK;
            }
            else
            {
                newNET.MaxY = line.EndY;
                newNET.MinX = line.StartX;
                newNET.DeltaX = line.ReciprocalK;
            }

            if (origin == null)
            {
                origin = newNET;
            }
            else
            {
                InsertNext(origin, newNET);
            }
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

                if (y2 != y1)
                {
                    line.ReciprocalK = (x2 - x1 + 0m) / (y2 - y1+0m);
                }
            }
            return lines;
        }
    }
}
