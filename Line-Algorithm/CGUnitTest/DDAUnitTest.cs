using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Line_Algorithm;
using System.Linq;
namespace CGUnitTest
{
    [TestClass]
    public class DDAUnitTest
    {
        ILineAlgorithm dDA = new DDA();
        [TestMethod]
        public void LTOneTest()
        {
            Point startPoint = new Point()
            {
                X = 0,
                Y = 0,
                RealX = 0,
                RealY = 0
            };
            Point endPoint = new Point()
            {
                X = 5,
                Y = 3,
                RealX = 5,
                RealY = 3
            };
            var points = dDA.GetPoints(startPoint, endPoint).ToList();

            Assert.AreEqual(6, points.Count);
        }
        [TestMethod]
        public void LTOneMinusTest()
        {
            Point startPoint = new Point()
            {
                X = 0,
                Y = 3,
                RealX = 0,
                RealY = 3
            };
            Point endPoint = new Point()
            {
                X = 5,
                Y = 0,
                RealX = 5,
                RealY = 0
            };
            var points = dDA.GetPoints(startPoint, endPoint).ToList();

            Assert.AreEqual(6, points.Count);
        }
    }
}
