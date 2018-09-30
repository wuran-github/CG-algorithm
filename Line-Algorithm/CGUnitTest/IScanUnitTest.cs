using Line_Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGUnitTest
{
    [TestClass]
    public class IScanUnitTest
    {
        [TestMethod]
        public void CheckPoint()
        {
            List<Point> points = new List<Point>()
            {
                new Point()
                {
                    X =2,
                    Y =2
                },
                new Point()
                {
                    X =5,
                    Y =1
                },
                 new Point()
                {
                    X =11,
                    Y =3
                },
                  new Point()
                {
                    X =11,
                    Y =8
                },
                   new Point()
                {
                    X =5,
                    Y =5
                },
                    new Point()
                {
                    X =2,
                    Y =7
                },
            };

            ImprovedScan xs = new ImprovedScan();
            var p2 = xs.GetPoints(points).ToList();
            var i = p2.Count;
        }
    }
}
