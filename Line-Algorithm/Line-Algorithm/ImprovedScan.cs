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
                List<Line> lineList = new List<Line>();
                for(int i=0;i<lines.Count;i++)
                {
                    if (lines[i].StartY == Y || lines[i].EndY == Y)
                    {
                        AddNET(lines[i], dictNET, Y);
                        lineList.Add(lines[i]);
                    }
                    
                }
                foreach(var line in lineList)
                {
                    lines.Remove(line);
                }
            }
            for (int Y = minY; Y <= maxY; Y++)
            {
                if (dictNET[Y] != null)
                {
                    var newNET = dictNET[Y];
                    while (newNET != null)
                    {
                        InsertAET(newNET, ref aet);
                        newNET = newNET.Next;
                    }
                }
                #region 遍历删除点

                DeleteAET(ref aet, Y);
                #endregion
                if (aet != null)
                {
                    #region 遍历得到点
                    AET left = null;
                    AET right = null;
                    
                    left = aet;
                    right = aet.Next;
                    while (left != null && right != null)
                    {
                        var tempPoints = GetPointsByAET(left, right, Y);
                        pointList.AddRange(tempPoints);
                        left = right.Next;
                        if (left != null)
                        {
                            right = left.Next;
                        }
                    }
                    #endregion

                    UpdateAET(ref aet);
                   

                }
            }

            return pointList;
        }
        List<Point> GetPointsByAET(AET left,AET right,int Y)
        {
            List<Point> points = new List<Point>();

            for(int i = left.X; i <= right.X; i++)
            {
                Point point = new Point()
                {
                    X = i,
                    Y = Y
                };
                points.Add(point);
            }
            return points;
        }
        void DeleteAET(ref AET aet,int Y)
        {
            if (aet == null)
            {
                return;
            }
            AET nextAET = null;
            AET nowAET = null;
            AET lastAET = null;
            nowAET = aet;
            lastAET = aet;
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
                        lastAET.Next = nowAET.Next;
                    }
                }
                nowAET = nowAET.Next;
                if (nowAET != null)
                {
                    nextAET = nowAET.Next;
                }
                if (!lastAET.Equals(aet))
                {
                    lastAET = lastAET.Next;
                }
            }
        }
        void UpdateAET(ref AET aet) {
            AET nowAET = null;
            nowAET = aet;
            while (nowAET != null)
            {
                nowAET.X = (int)(nowAET.DeltaX + nowAET.X);
                nowAET = nowAET.Next;

            }
        }
        void InsertAET(NET net,ref AET aet)
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
        void AddNET(Line line, Dictionary<int, NET> dict,int Y)
        {
            NET newNET = new NET();
            if (line.StartY > line.EndY)
            {
                newNET.MaxY = line.StartY;
                newNET.MinX = line.EndX;
                newNET.DeltaX = line.ReciprocalK;
                newNET.MaxX = line.StartX;
            }
            else
            {
                newNET.MaxY = line.EndY;
                newNET.MinX = line.StartX;
                newNET.DeltaX = line.ReciprocalK;
                newNET.MaxX = line.EndX;
            }

            if (dict[Y] == null)
            {
                dict[Y] = newNET;
            }
            else
            {
                var tempNET = dict[Y];
                InsertNext(ref tempNET, newNET);
                dict[Y] = tempNET;
            }
        }
        //需要排序
        void InsertNext(ref NET origin,NET newNET)
        {
            NET lastNET = null;
            NET nowNET = null;
            bool inserted = false;
            nowNET = origin;
            while (nowNET != null)
            {
                if (nowNET.MaxX > newNET.MaxX)
                {
                    //first node
                    if (lastNET == null)
                    {
                        NET temp = nowNET;
                        origin = newNET;
                        newNET.Next = temp;
                    }
                    else
                    {
                        lastNET.Next = newNET;
                        newNET.Next = nowNET;
                    }
                    inserted = true;
                    break;
                }
                else
                {
                    lastNET = nowNET;
                    nowNET = nowNET.Next;
                }
            }
            if (!inserted)
            {
                lastNET.Next = newNET;
            }
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
                lines.Add(line);
            }
            return lines;
        }
    }
}
